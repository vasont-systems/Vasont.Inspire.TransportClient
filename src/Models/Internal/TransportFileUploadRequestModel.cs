//-----------------------------------------------------------------------
// <copyright file="TransportFileUploadRequestModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using System;

    /// <summary>
    /// This class represents the <see cref="TransportFileUploadRequestModel"/> that's used when submitting request to upload files to Transport.
    /// </summary>
    internal class TransportFileUploadRequestModel
    {
        /// <summary>
        /// Gets or sets the file stream that's used to upload a file to Transport.
        /// </summary>
        public byte[] FileStream { get; set; }

        /// <summary>
        /// Gets or sets the file path of the local file that's needed to upload a file to Transport.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the TargetFolderId with the folder Id from the project template.
        /// </summary>
        public Guid TargetFolderId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if it's okay to overwrite the file if it already exists on Transport side.
        /// </summary>
        public bool OverwriteFile { get; set; }
    }
}
