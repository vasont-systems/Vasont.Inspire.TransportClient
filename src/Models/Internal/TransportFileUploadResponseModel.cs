//-----------------------------------------------------------------------
// <copyright file="TransportFileUploadResponseModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// This class represents the <see cref="TransportFileUploadResponseModel"/> that's received after uploading files to Transport.
    /// </summary>
    class TransportFileUploadResponseModel
    {
        [JsonProperty("id")]
        public string FileId { get; set; }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }

        [JsonProperty("parentId")]
        public string FolderId { get; set; }

        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("fileSizeString")]
        public string FileSizeString { get; set; }

        [JsonProperty("fileSize")]
        public long FileSize { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
