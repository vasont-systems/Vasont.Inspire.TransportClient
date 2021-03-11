//-------------------------------------------------------------
// <copyright file="Program.cs" company="Vasont Systems">
// Copyright (c) Vasont Systems. All rights reserved.
// </copyright>
//-------------------------------------------------------------
namespace TestTransportClient
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Vasont.Inspire.Core.Extensions;
    using Vasont.Inspire.Core.Utility;
    using Vasont.Inspire.TransportClient;
    using Vasont.Inspire.TransportClient.Models;

    /// <summary>
    /// This is the main entry point of the Test Project Director Client Console Application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            string resourceUri = CommandLine.Parameters.ContainsKey("resourceUrl") ? CommandLine.Parameters["resourceUrl"].ConvertToString() : string.Empty;
            string authorityUri = CommandLine.Parameters.ContainsKey("authorityUri") ? CommandLine.Parameters["authorityUri"].ConvertToString() : string.Empty;
            string userName = CommandLine.Parameters.ContainsKey("userName") ? CommandLine.Parameters["userName"].ConvertToString() : string.Empty;
            string password = CommandLine.Parameters.ContainsKey("password") ? CommandLine.Parameters["password"].ConvertToString() : string.Empty;

            string clientSecret = CommandLine.Parameters.ContainsKey("clientSecret") ? CommandLine.Parameters["clientSecret"].ConvertToString() : string.Empty;
            string clientId = CommandLine.Parameters.ContainsKey("clientId") ? CommandLine.Parameters["clientId"].ConvertToString() : string.Empty;

            string grantType = CommandLine.Parameters.ContainsKey("grantType") ? CommandLine.Parameters["grantType"].ConvertToString() : string.Empty;
            string clientScopes = CommandLine.Parameters.ContainsKey("clientScopes") ? CommandLine.Parameters["clientScopes"].ConvertToString() : string.Empty;

            string projectId = CommandLine.Parameters.ContainsKey("projectId") ? CommandLine.Parameters["projectId"].ConvertToString() : string.Empty;
            string runScope = CommandLine.Parameters.ContainsKey("runScope") ? CommandLine.Parameters["runScope"].ConvertToString() : "CreateProject";  // valid values can be "CreateProject", "FetchAndDownloadCompletedFiles"

            Console.WriteLine("GlobalLink Vasont Inspire Transport Api Client Test.");

            try
            {
                TransportAuthenticationModel authenticationSettings = new TransportAuthenticationModel
                {
                    AuthorityUri = authorityUri,
                    ClientId = clientId,
                    ClientScopes = clientScopes,
                    ClientSecret = clientSecret,
                    GrantType = grantType,
                    Password = password,
                    RESTUrl = resourceUri,
                    RoutePrefix = "/api",
                    Username = userName
                };

                using (var transportClient = new TransportClient(authenticationSettings))
                {
                    switch (runScope)
                    {
                        case "CreateProject":
                            // Sample code to test creating projects and uploading files to a project
                            Console.WriteLine("Authentication successful. Creating a Transport project...");

                            TransportSubmissionProjectModel projectModel = new TransportSubmissionProjectModel();
                            projectModel.ProjectName = "Test Project from the Transport Test Client - 01-07-21-2";
                            projectModel.ProjectDescription = "This test project was created using the Transport Test Client - 3-3";
                            projectModel.SourceLanguage = "en";
                            projectModel.TargetLanguages = new List<string> { "fr" };

                            // compose the files that are needed to be uploaded to Transport
                            projectModel.FilesToUpload.Add(new TransportSubmissionProjectFileModel
                            {
                                FilePath = "InspireTransportWorkflow_draft.docx"
                            });

                            projectModel.CustomFields.Add("SampleDropdown", "Dropdown-Value-1");
                            projectModel.CustomFields.Add("SampleText", "Text-Value-1");
                            projectModel.CustomFields.Add("SampleCheckbox", "Checkbox-Value-1");
                            projectModel.CustomFields.Add("TenantKey", "localhost");

                            TransportSubmissionResponseModel transportResponseModel = await transportClient.SubmitProjectAsync(projectModel);

                            if (transportResponseModel != null)
                            {
                                Console.WriteLine($"Transport project created! Transport Project# {transportResponseModel.TransportProjectNumber}");
                            }
                            else
                            {
                                Console.WriteLine($"Error creating Transport project.");
                            }

                            break;
                        case "FetchAndDownloadCompletedFiles":
                            // Sample code to test completed files for a project and download them
                            Console.WriteLine("Getting Transport project info...");

                            List<TransportLegacyFileModel> completedFiles = await transportClient.GetCompletedFilesAsync(new Guid(projectId));

                            if (completedFiles != null)
                            {
                                Console.WriteLine($"Transport completed files count = {completedFiles.Count}");

                                Console.WriteLine("Downloading project files...");
                                completedFiles.ForEach(async file =>
                                {
                                    try
                                    {
                                        string filename = $"{file.FileName}.{file.FileType}";
                                        TransportFileDownloadRequestModel fileDownloadRequestModel = new TransportFileDownloadRequestModel();
                                        fileDownloadRequestModel.FileId = new Guid(file.FileId);
                                        fileDownloadRequestModel.FileName = filename;

                                        Console.WriteLine($"Downloading project file {filename}...");

                                        TransportFileDownloadResponseModel fileDownloadResponseModel = await transportClient.DownloadFileAsync(fileDownloadRequestModel);

                                        if (fileDownloadResponseModel != null)
                                        {
                                            // add to the import request model
                                            Console.WriteLine($"Downloaded {fileDownloadResponseModel.FileName}. File stream length = {fileDownloadResponseModel.FileStreamLength}");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error downloading file. Exception: {ex.Message}");
                                    }
                                });
                            }
                            else
                            {
                                Console.WriteLine($"Error fetching completed files.");
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An Exception was thrown. {Environment.NewLine} Error: {ex.Message} {Environment.NewLine} Stack Trace: {ex.StackTrace} Environment.NewLine");
            }

            // wait
            Console.WriteLine("Press any key to close this console window.");
            Console.ReadKey();
        }
    }
}
