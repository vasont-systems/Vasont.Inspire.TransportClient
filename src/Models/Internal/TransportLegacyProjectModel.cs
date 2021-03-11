//-----------------------------------------------------------------------
// <copyright file="TransportLegacyProjectModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportLegacyProjectModel"/> that's received after requesting project info from Transport.
    /// </summary>
    public class TransportLegacyProjectModel
    {
        /// <summary>
        /// Gets or sets the list of folders from Transport project.
        /// </summary>
        [JsonProperty("folderDetails")]
        public List<TransportLegacyFolderModel> FolderDetails { get; set; }
    }
}
