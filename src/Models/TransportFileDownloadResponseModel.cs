//-----------------------------------------------------------------------
// <copyright file="TransportFileDownloadResponseModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    using Newtonsoft.Json;
    using System;
    using System.IO;

    /// <summary>
    /// This class represents the <see cref="TransportFileDownloadResponseModel"/> that's received after downloading a file from Transport.
    /// </summary>
    public class TransportFileDownloadResponseModel
    {
        /// <summary>
        /// Gets or sets the file identifier of the remote file from Transport.
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Gets or sets the filename of the remote file from Transport.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file type of the remote file from Transport.
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file stream of the remote file from Transport.
        /// </summary>
        public Stream FileStream { get; set; }

        /// <summary>
        /// Gets or sets the file stream length of the remote file from Transport.
        /// </summary>
        public long FileStreamLength { get; set; }

        /// <summary>
        /// Gets or sets the any errors received from Transport.
        /// </summary>
        public string Error { get; set; }
    }
}
