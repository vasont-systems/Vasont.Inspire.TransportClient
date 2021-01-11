//-----------------------------------------------------------------------
// <copyright file="TransportProjectFilesModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportProjectFilesModel"/> that's referenced in the <see cref="TransportProjectCreateModel"/>.
    /// </summary>
    internal class TransportProjectFilesModel
    {
        [JsonProperty("id")]
        internal string FileId { get; set; }

        [JsonProperty("operation")]
        internal int Operation { get; set; }

        [JsonProperty("filename")]
        internal string FileName { get; set; }

        [JsonProperty("targetFolderId")]
        internal string TargetFolderId { get; set; }
    }
}
