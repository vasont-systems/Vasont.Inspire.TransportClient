//-----------------------------------------------------------------------
// <copyright file="TransportClient.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Vasont.Inspire.TransportClient.Models;
    using Vasont.Inspire.TransportClient.Models.Internal;

    /// <summary>
    /// This class represents the <see cref="TransportClient"/> that facilitates interacting with the Transport REST APIs.
    /// </summary>
    public class TransportClient : BaseClient
    {
        /// <summary>
        /// This constructor method.
        /// </summary>
        /// <param name="authenticationModel">The <see cref="TransportAuthenticationModel"/> model that carries the authentication info.</param>
        public TransportClient(TransportAuthenticationModel authenticationModel)
            : base(authenticationModel)
        {
        }

        #region Public-facing Methods

        /// <summary>
        /// This method will submit the project to Transport. This is a wrapper method that hides the many details involved in submitting
        /// a project to Transport.
        /// </summary>
        /// <param name="projectModel">The <see cref="TransportSubmissionProjectModel"/> model that carries the project info.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="TransportSubmissionResponseModel"/> model.</returns>
        public async Task<TransportSubmissionResponseModel> SubmitProjectAsync(TransportSubmissionProjectModel projectModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            TransportProjectTemplateModel projectTemplateResponseModel;
            TransportProjectTemplateModel projectCreateResponseModel = null;
            TransportSubmissionResponseModel responseModel = null;
            TransportProjectRequestModel requestModel = new TransportProjectRequestModel();

            // Authenticate to make sure we can communicate with Transport
            if (EnsureAuthentication(cancellationToken).Result)
            {
                // Step-1: retrieve the project template
                projectTemplateResponseModel = await this.RetrieveProjectTemplatesAsync(cancellationToken);

                if (projectTemplateResponseModel != null && projectTemplateResponseModel.ProjectId.Length > 0)
                {
                    // Step-2: we've got a project template, now upload files
                    if (projectModel.FilesToUpload != null && projectModel.FilesToUpload.Count > 0)
                    {
                        // we've got some files to upload, and also to add to the Files collection of a Transport project 
                        TransportFileUploadResponseModel fileUploadResponseModel = null;
                        foreach (TransportSubmissionProjectFileModel projectFile in projectModel.FilesToUpload)
                        {
                            TransportFileUploadRequestModel file = new TransportFileUploadRequestModel
                            {
                                FilePath = projectFile.FilePath,
                                FileStream = projectFile.FileStream,
                                TargetFolderId = new Guid(projectTemplateResponseModel.Folders.SourceFiles),
                                OverwriteFile = true,
                            };

                            fileUploadResponseModel = await this.UploadFilesAsync(file, cancellationToken);

                            if (fileUploadResponseModel != null && fileUploadResponseModel.Error == null)
                            {
                                requestModel.Files.Add(
                                    new TransportProjectFileModel
                                    {
                                        FileId = fileUploadResponseModel.FileId,
                                        Operation = 2,
                                        FileName = $"{fileUploadResponseModel.FileName}.{fileUploadResponseModel.FileType}",
                                        TargetFolderId = fileUploadResponseModel.FolderId
                                    });
                            }
                            else
                            {
                                // upload failed, halt creating the project and return
                                this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                                {
                                    ErrorType = Core.Errors.ErrorType.Critical,
                                    Message = "Failed to upload one or more files to Transport as part of the project creation."
                                });
                            }
                        }

                        // Step-3: if all files have been uploaded then proceed to create the project
                        requestModel.ProjectId = new Guid(projectTemplateResponseModel.ProjectId);
                        requestModel.ProjectName = projectModel.ProjectName;
                        requestModel.SourceLanguage = projectModel.SourceLanguage;
                        requestModel.TargetLanguages = projectModel.TargetLanguages;
                        requestModel.DeadlineTypes = new List<string> { "TurnaroundTime" };
                        requestModel.TurnaroundTime = 0;
                        requestModel.QuoteRequired = true;
                        requestModel.Description = projectModel.ProjectDescription;

                        // include custom fields, project model could hold the full list of custom fields that we may not be interested in, 
                        // so, filter out and send only those that's mentioned in the project template. If there are no custom fields mentioned in 
                        // the project template then don't bother sending any.
                        if (projectModel.CustomFields.Count > 0 && projectTemplateResponseModel.CustomFields != null && projectTemplateResponseModel.CustomFields.Count > 0)
                        {
                            foreach (KeyValuePair<string, string> customField in projectModel.CustomFields)
                            {
                                if (projectTemplateResponseModel.CustomFields.ContainsKey(customField.Key))
                                {
                                    requestModel.CustomFields.Add(customField.Key, customField.Value);
                                }
                            }
                        }

                        projectCreateResponseModel = await this.CreateProjectAsync(requestModel, cancellationToken);

                        if (projectCreateResponseModel == null)
                        {
                            // project creation failed, return appropriate message
                            this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                            {
                                ErrorType = Core.Errors.ErrorType.Critical,
                                Message = "Failed to create a Transport project with the provided information."
                            });
                        } 
                        else
                        {
                            responseModel = new TransportSubmissionResponseModel();
                            responseModel.ProjectId = projectCreateResponseModel.ProjectId;
                            responseModel.TransportProjectNumber = projectCreateResponseModel.TransportProjectNumber;
                            responseModel.SubmissionRequest = JsonConvert.SerializeObject(requestModel);
                            responseModel.SubmissionResponse = JsonConvert.SerializeObject(projectCreateResponseModel);
                        }
                    }
                }
                else
                {
                    // couldn't retrieve the project template, return appropriate message
                    this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                    {
                        ErrorType = Core.Errors.ErrorType.Critical,
                        Message = "Couldn't retrieve a valid project template from Transport."
                    });
                }
            }
            else
            {
                // authentication failed, return appropriate message
                this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                {
                    ErrorType = Core.Errors.ErrorType.Fatal,
                    Message = "Failed to authenticate with Transport."
                });
            }

            return responseModel;
        }

        /// <summary>
        /// This method will retrieve a list of completed files for a Transport project.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a list of <see cref="TransportLegacyFileModel"/> model.</returns>
        public async Task<List<TransportLegacyFileModel>> GetCompletedFilesAsync(Guid projectId, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<TransportLegacyFileModel> fileModel = null;
            TransportLegacyProjectModel projectModel = null;
            List<TransportLegacyFolderModel> folderModel = null;

            // Authenticate to make sure we can communicate with Transport
            if (EnsureAuthentication(cancellationToken).Result)
            {
                var request = CreateRequest($"/projects/{projectId}", HttpMethod.Get);

                projectModel = RequestContent<TransportLegacyProjectModel>(request);

                if (projectModel != null && projectModel.FolderDetails != null && projectModel.FolderDetails.Count > 0)
                {
                    folderModel = projectModel.FolderDetails;
                    List<TransportLegacyFolderModel> completedFilesFolder = folderModel.FindAll(f => f.Action == "Completed Files");

                    if (completedFilesFolder != null && completedFilesFolder.Count > 0)
                    {
                        if (completedFilesFolder[0].ProjectFiles != null && completedFilesFolder[0].ProjectFiles.Count > 0)
                        {
                            fileModel = new List<TransportLegacyFileModel>();

                            completedFilesFolder[0].ProjectFiles.ForEach(f =>
                            {
                                fileModel.Add(new TransportLegacyFileModel
                                {
                                    FileId = f.FileId,
                                    FileName = f.FileName,
                                    FileType = f.FileType,
                                    IsDeleted = f.IsDeleted
                                });
                            });
                        }
                    }
                }
            }

            return fileModel;
        }

        /// <summary>
        /// This method will download completed files from a Transport project.
        /// </summary>
        /// <param name="requestModel">The <see cref="TransportFileDownloadRequestModel"/> model that carries the request info.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="TransportFileDownloadResponseModel"/> model.</returns>
        public async Task<TransportFileDownloadResponseModel> DownloadFileAsync(TransportFileDownloadRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            TransportFileDownloadResponseModel responseModel = null;

            if (requestModel != null)
            {
                if (EnsureAuthentication(cancellationToken).Result)
                {
                    HttpClient client = new HttpClient();

                    try
                    {
                        string fileDownloadUrl = $"{this.Configuration.ResourceUri}{this.Configuration.RoutePrefix}/Download/files?portalEntryIds={requestModel.FileId.ToString()}";
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
                        var httpResponse = await client.GetAsync(fileDownloadUrl, cancellationToken);
                        httpResponse.EnsureSuccessStatusCode();
                        responseModel = new TransportFileDownloadResponseModel();
                        responseModel.FileStream = await httpResponse.Content.ReadAsStreamAsync();
                        responseModel.FileId = requestModel.FileId;
                        responseModel.FileName = requestModel.FileName;
                        responseModel.FileStreamLength = responseModel.FileStream.Length;
                    }
                    catch (Exception ex)
                    {
                        this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                        {
                            ErrorType = Core.Errors.ErrorType.Critical,
                            Message = $"Failed to download file from Transport. Message: {ex.Message}"
                        });
                    }
                }
            }

            return responseModel;
        }

        #endregion

        /// <summary>
        /// This internal method will call the API endpoints to retrieve the project template from Transport.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="TransportProjectTemplateModel"/> model.</returns>
        internal async Task<TransportProjectTemplateModel> RetrieveProjectTemplatesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            TransportProjectTemplateModel response = null;

            // Once we've successfully authenticated call the Api endpoint to get project templates.
            if (EnsureAuthentication(cancellationToken).Result)
            {
                var request = CreateRequest($"/v2/projects/template");
                
                response = RequestContent<TransportProjectTemplateModel>(request);
            }

            return response;
        }

        /// <summary>
        /// This internal method will call the API endpoints to create a Transport project.
        /// </summary>
        /// <param name="requestModel">The <see cref="TransportProjectRequestModel"/> model that carries the request info.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="TransportProjectTemplateModel"/> model.</returns>
        internal async Task<TransportProjectTemplateModel> CreateProjectAsync(TransportProjectRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            TransportProjectTemplateModel response = null;

            // Once we've successfully authenticated call the Api endpoint to create the project.
            if (EnsureAuthentication(cancellationToken).Result)
            {
                var request = CreateRequest($"/v2/projects/{requestModel.ProjectId}", HttpMethod.Post);

                response = RequestContent<TransportProjectRequestModel, TransportProjectTemplateModel>(request, requestModel);
            }

            return response;
        }

        /// <summary>
        /// This internal method will call the API endpoints to update a Transport project.
        /// </summary>
        /// <param name="requestModel">The <see cref="TransportProjectRequestModel"/> model that carries the request info.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns the success status of the call to update a Transport project.</returns>
        internal async Task<bool> UpdateProjectAsync(TransportProjectRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                var request = this.CreateRequest($"/v2/projects/{requestModel.ProjectId}", HttpMethod.Put);

                // TODO create response model
                this.RequestContent<TransportProjectRequestModel, string>(request, requestModel);
            }

            return true;
        }

        #region Attempt to upload file using WebRequest that didn't work

        //public TransportFileUploadResponseModel UploadFiles(TransportFileUploadRequestModel requestModel) //, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    TransportFileUploadResponseModel response = null;
        //    CancellationToken cancellationToken = default(CancellationToken);

        //    if (EnsureAuthentication(cancellationToken).Result)
        //    {
        //        ASCIIEncoding ascii = new ASCIIEncoding();
        //        string boundary = "----WebKitFormBoundary" + DateTime.Now.Ticks.ToString("x");

        //        string uploaderName = "srcUploader";
        //        //byte[] boundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
        //        string acceptType = "application/json";
        //        string contentType = "pdf";
        //        string fileUrl = requestModel.FilePath;

        //        var request = this.CreateRequestMultipart($"/files/upload?filename={requestModel.FilePath}&targetFolderId={requestModel.TargetFolderId}&overwrite={requestModel.OverwriteFile}", HttpMethod.Post.Method, false, null, acceptType, boundary);

        //        string boundaryStringLine = "\r\n--" + boundary + "\r\n";
        //        byte[] boundaryStringLineBytes = System.Text.Encoding.Default.GetBytes(boundaryStringLine);

        //        string lastBoundaryStringLine = "\r\n--" + boundary + "--\r\n";
        //        byte[] lastBoundaryStringLineBytes = System.Text.Encoding.Default.GetBytes(lastBoundaryStringLine);

        //        // Get the byte array of the myFileDescription content disposition
        //        string myFileDescriptionContentDisposition = String.Format(
        //            "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
        //            Path.GetFileName(fileUrl),
        //            "A sample file description");
        //        byte[] myFileDescriptionContentDispositionBytes
        //            = System.Text.Encoding.Default.GetBytes(myFileDescriptionContentDisposition);

        //        switch (Path.GetExtension(fileUrl).Replace(".", ""))
        //        {
        //            case "pdf":
        //                contentType = "pdf";
        //                break;
        //            case "doc":
        //                contentType = "msword";
        //                break;
        //            case "docx":
        //                contentType = "vnd.openxmlformats-officedocument.wordprocessingml.document";
        //                break;
        //            case "xls":
        //                contentType = "vnd.ms-excel";
        //                break;
        //            case "xlsx":
        //                contentType = "vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //                break;
        //            case "xml":
        //                contentType = "xml";
        //                break;
        //        }

        //        string myFileContentDisposition = String.Format(
        //            "Content-Disposition: form-data; name=\"{0}\"; "
        //             + "filename=\"{1}\"\r\nContent-Type: application/{2}\r\n\r\n",
        //            uploaderName, Path.GetFileName(fileUrl), contentType);
        //        byte[] myFileContentDispositionBytes =
        //            System.Text.Encoding.Default.GetBytes(myFileContentDisposition);

        //        //FileInfo fileInfo = new FileInfo(fileUrl);
        //        var fileInfo = File.ReadAllBytes(requestModel.FilePath);

        //        // Calculate the total size of the HTTP request
        //        long totalRequestBodySize = boundaryStringLineBytes.Length * 2
        //            + lastBoundaryStringLineBytes.Length
        //            + myFileDescriptionContentDispositionBytes.Length
        //            + myFileContentDispositionBytes.Length
        //            + fileInfo.Length;
        //        // And indicate the value as the HTTP request content length
        //        request.ContentLength = totalRequestBodySize;

        //        var requestStream = request.GetRequestStream();
        //        {
        //            // Send the file description content disposition over to the server
        //            requestStream.Write(boundaryStringLineBytes, 0, boundaryStringLineBytes.Length);
        //            requestStream.Write(myFileDescriptionContentDispositionBytes, 0,
        //                myFileDescriptionContentDisposition.Length);

        //            // Send the file content disposition over to the server
        //            requestStream.Write(boundaryStringLineBytes, 0, boundaryStringLineBytes.Length);
        //            requestStream.Write(myFileContentDispositionBytes, 0,
        //                myFileContentDispositionBytes.Length);

        //            byte[] buffer = new byte[1024];
        //            int bytesRead = 0;

        //            if (requestModel.FileStream == null)
        //            {
        //                // upload from the file path
        //                using (FileStream fileStream = File.OpenRead(requestModel.FilePath))
        //                {
        //                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
        //                    {
        //                        requestStream.Write(buffer, 0, bytesRead);
        //                    }
        //                    fileStream.Flush();
        //                    fileStream.Close();
        //                }
        //            }
        //            else
        //            {
        //                // upload from the given file stream
        //                while ((bytesRead = requestModel.FileStream.Read(buffer, 0, buffer.Length)) != 0)
        //                {
        //                    requestStream.Write(buffer, 0, bytesRead);
        //                }
        //            }

        //            //var streamWriter = new StreamWriter(requestStream);
        //            //streamWriter.Write(binary);
        //            //streamWriter.Flush();

        //            // Send the last part of the HTTP request body
        //            requestStream.Write(lastBoundaryStringLineBytes, 0, lastBoundaryStringLineBytes.Length);
        //            requestStream.Flush();
        //        }

        //        response = this.RequestContent<TransportFileUploadResponseModel>(request);
        //    }
        //    return response;
        //}

        #endregion

        /// <summary>
        /// This internal method will call the API endpoints to upload a file to a Transport project.
        /// </summary>
        /// <param name="requestModel">The <see cref="TransportFileUploadRequestModel"/> model that carries the request info.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Returns a <see cref="TransportFileUploadResponseModel"/> model.</returns>
        internal async Task<TransportFileUploadResponseModel> UploadFilesAsync(TransportFileUploadRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<TransportFileUploadResponseModel> responseList = null;

            if (EnsureAuthentication(cancellationToken).Result)
            {
                HttpClient client = new HttpClient();
                MultipartFormDataContent form = new MultipartFormDataContent();
                byte[] fileContent = null;
                string fileName = Path.GetFileName(requestModel.FilePath);

                if (requestModel.FileStream == null || requestModel.FileStream.Length <= 0)
                {
                    // file stream was not provided, read from the file
                    fileContent = await File.ReadAllBytesAsync(requestModel.FilePath, cancellationToken);
                }
                else
                {
                    // a file stream was provided, use the stream instead
                    fileContent = requestModel.FileStream;
                }

                var httpContent = new ByteArrayContent(fileContent);
                httpContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                if (!string.IsNullOrEmpty(requestModel.FilePath))
                {
                    form.Add(httpContent, "file", Path.GetFileName(requestModel.FilePath));
                }

                try
                {
                    string fileUploadUrl = $"{this.Configuration.ResourceUri}{this.Configuration.RoutePrefix}/files/upload?filename={fileName}&targetFolderId={requestModel.TargetFolderId}&overwrite={requestModel.OverwriteFile}";
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
                    var httpResponse = await client.PostAsync(fileUploadUrl, form, cancellationToken);
                    httpResponse.EnsureSuccessStatusCode();
                    var responseContent = httpResponse.Content.ReadAsStringAsync();
                    responseList = JsonConvert.DeserializeObject<List<TransportFileUploadResponseModel>>(responseContent.Result);
                }
                catch (Exception ex)
                {
                    this.LastErrorResponse.Messages.Add(new Inspire.Models.Common.ErrorModel
                    {
                        ErrorType = Core.Errors.ErrorType.Critical,
                        Message = $"Failed to upload file to a Transport project. Message: {ex.Message}"
                    });
                }
            }
            return responseList != null && responseList.Count > 0 ? responseList[0] : null;
        }
    }
}
