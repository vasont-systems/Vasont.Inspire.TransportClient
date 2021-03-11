//-----------------------------------------------------------------------
// <copyright file="TransportLegacyFolderModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportLegacyFolderModel"/> that's received after requesting project info from Transport.
    /// </summary>
    public class TransportLegacyFolderModel
    {
        /// <summary>
        /// Gets or sets the file identifier of the completed file from Transport.
        /// </summary>
        [JsonProperty("id")]
        public string FileId { get; set; }

        /// <summary>
        /// Gets or sets the action name of the file from Transport.
        /// </summary>
        [JsonProperty("name")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets a list of files that belong to a project from Transport.
        /// </summary>
        [JsonProperty("files")]
        public List<TransportLegacyFileModel> ProjectFiles { get; set; }
    }
}
