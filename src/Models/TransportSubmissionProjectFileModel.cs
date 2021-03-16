//-----------------------------------------------------------------------
// <copyright file="TransportSubmissionProjectFileModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    /// <summary>
    /// This class represents the <see cref="TransportSubmissionProjectFileModel"/> that's used to represent a project file.
    /// </summary>
    public class TransportSubmissionProjectFileModel
    {
        /// <summary>
        /// Gets or sets the full file path inforamtion for uploading files to Transport.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the full file stream for uploading files to Transport.
        /// </summary>
        public byte[] FileStream { get; set; }
    }
}
