//-----------------------------------------------------------------------
// <copyright file="TransportFileDownloadRequestModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    using System;

    /// <summary>
    /// This class represents the <see cref="TransportFileDownloadRequestModel"/> that's used when downloading a file from Transport.
    /// </summary>
    public class TransportFileDownloadRequestModel
    {
        /// <summary>
        /// Gets or sets the file identifier of the remote file on Transport.
        /// </summary>
        public Guid FileId { get; set; }

        /// <summary>
        /// Gets or sets the file name of the remote file on Transport.
        /// </summary>
        public string FileName { get; set; }
    }
}
