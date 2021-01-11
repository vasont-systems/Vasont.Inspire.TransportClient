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
    class TransportFileUploadRequestModel
    {
        public byte[] FileStream { get; set; }

        public string FilePath { get; set; }

        public Guid TargetFolderId { get; set; }

        public bool OverwriteFile { get; set; }
    }
}
