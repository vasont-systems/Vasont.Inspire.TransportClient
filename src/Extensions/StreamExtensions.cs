//-------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="Vasont Systems">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using Vasont.Inspire.Models.Transfers;
    using Vasont.Inspire.TransportClient.Models;

    /// <summary>
    /// This class contains static extensions for the Stream object.
    /// </summary>
    internal static class StreamExtensions
    {
        /// <summary>
        /// This extension method is used to write a multi-part form post to a specified stream.
        /// </summary>
        /// <param name="formDataStream">Contains the form data stream to write the output to.</param>
        /// <param name="formModel">Contains the form model object to serialize to the output.</param>
        /// <param name="boundary">Contains the boundary name for the multi-part data.</param>
        /// <param name="encoding">Contains an optional encoding for string data. By default, encoding is UTF8.</param>
        public static void WriteMultiPartFormData(this Stream formDataStream, TransportFileUploadRequestModel formModel, string boundary = "boundary", Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] lineBreakBytes = encoding.GetBytes("\r\n");

            // TODO get this working for transport
            //byte[] folderIdContentBytes = encoding.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
            //        boundary,
            //        "FolderId",
            //        formModel.TargetFolderId));

            //formDataStream.Write(folderIdContentBytes, 0, folderIdContentBytes.Length);
            //formDataStream.Write(lineBreakBytes, 0, lineBreakBytes.Length);

            //byte[] projectFolderIdContentBytes = encoding.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
            //        boundary,
            //        "ProjectFolderId",
            //        formModel.));

            //formDataStream.Write(projectFolderIdContentBytes, 0, projectFolderIdContentBytes.Length);
            //formDataStream.Write(lineBreakBytes, 0, lineBreakBytes.Length);

            //for (int i = 0; i < files.Count; i++)
            //{
            //    string file = files[i];

            string file = formModel.FilePath;

                if (File.Exists(file))
                {
                    string fileName = Path.GetFileName(file);

                        byte[] fileDataContentBytes = encoding.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: application/octet-stream\r\n\r\n",
                            boundary,
                            fileName, 
                            fileName));
                        formDataStream.Write(fileDataContentBytes, 0, fileDataContentBytes.Length);

                        byte[] fileData = File.ReadAllBytes(file);

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileData, 0, fileData.Length);
                        formDataStream.Write(lineBreakBytes, 0, lineBreakBytes.Length);
                    }
            //    }
            //}

            // Add the end of the request.  Start with a newline
            byte[] footerBytes = encoding.GetBytes("\r\n--" + boundary + "--\r\n");
            formDataStream.Write(footerBytes, 0, footerBytes.Length);
        }
    }
}
