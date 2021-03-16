//-----------------------------------------------------------------------
// <copyright file="TransportProjectFileModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportProjectFileModel"/> that's referenced in the <see cref="TransportProjectCreateModel"/>.
    /// </summary>
    internal class TransportProjectFileModel
    {
        /// <summary>
        /// Gets or sets the file identifier of the file that need to be uploaded to Transport.
        /// </summary>
        [JsonProperty("id")]
        internal string FileId { get; set; }

        /// <summary>
        /// Gets or sets the file operation of the file that need to be uploaded to Transport.
        /// </summary>
        [JsonProperty("operation")]
        internal int Operation { get; set; }

        /// <summary>
        /// Gets or sets the file name of the file that need to be uploaded to Transport.
        /// </summary>
        [JsonProperty("filename")]
        internal string FileName { get; set; }

        /// <summary>
        /// Gets or sets the target folder identifier of the file that need to be uploaded to Transport.
        /// </summary>
        [JsonProperty("targetFolderId")]
        internal string TargetFolderId { get; set; }
    }
}
