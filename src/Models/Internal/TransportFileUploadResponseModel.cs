//-----------------------------------------------------------------------
// <copyright file="TransportFileUploadResponseModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportFileUploadResponseModel"/> that's received after uploading files to Transport.
    /// </summary>
    internal class TransportFileUploadResponseModel
    {
        /// <summary>
        /// Gets or sets the file identifier param from Transport for the file that just got uploaded.
        /// </summary>
        [JsonProperty("id")]
        public string FileId { get; set; }

        /// <summary>
        /// Gets or sets the filename of the file that just got uploaded to Transport.
        /// </summary>
        [JsonProperty("name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file type of the file that just got uploaded to Transport.
        /// </summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the folder identifier of the file that just got uploaded to Transport.
        /// </summary>
        [JsonProperty("parentId")]
        public string FolderId { get; set; }

        /// <summary>
        /// Gets or sets the date when this file got added to Transport.
        /// </summary>
        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Gets or sets the file size in string format as sensed by Transport.
        /// </summary>
        [JsonProperty("fileSizeString")]
        public string FileSizeString { get; set; }

        /// <summary>
        /// Gets or sets the file size in numeric format as sensed by Transport.
        /// </summary>
        [JsonProperty("fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// Gets or sets the any errors received from Transport.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
