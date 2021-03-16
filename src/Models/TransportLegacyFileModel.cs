//-----------------------------------------------------------------------
// <copyright file="TransportLegacyFileModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportLegacyFileModel"/> that's represents a project file from Transport.
    /// </summary>
    public class TransportLegacyFileModel
    {
        /// <summary>
        /// Gets or sets the file identifier of the completed file from Transport.
        /// </summary>
        [JsonProperty("id")]
        public string FileId { get; set; }

        /// <summary>
        /// Gets or sets the filename of the remote file from Transport.
        /// </summary>
        [JsonProperty("name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file type of the remote file from Transport.
        /// </summary>
        [JsonProperty("fileType")]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets an indicator whether the file got deleted from Transport.
        /// </summary>
        [JsonProperty("deleted")]
        public bool IsDeleted { get; set; }
    }
}
