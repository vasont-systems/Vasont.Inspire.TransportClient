//-----------------------------------------------------------------------
// <copyright file="TransportProjectResponseModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    internal class TransportProjectResponseModel
    {
        public TransportProjectResponseModel()
        {
            this.TargetLanguages = new List<string>();
            this.DeadlineTypes = new List<string>();
            this.Files = new List<TransportLegacyFolderModel>();
        }

        /// <summary>
        /// Gets or sets the project identifier value from Transport.
        /// </summary>
        [JsonProperty("id")]
        internal Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name from Transport.
        /// </summary>
        [JsonProperty("projectName")]
        internal string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the source language from Transport.
        /// </summary>
        [JsonProperty("sourceLanguage")]
        internal string SourceLanguage { get; set; }

        /// <summary>
        /// Gets or sets a list of target languages from Transport.
        /// </summary>
        [JsonProperty("targetLanguages")]
        internal List<string> TargetLanguages { get; set; }

        /// <summary>
        /// Gets or sets the date this project got created on Transport.
        /// </summary>
        [JsonProperty("dateCreated")]
        internal string CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date this project got modified on Transport.
        /// </summary>
        [JsonProperty("dateModified")]
        internal string ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets a list of deadline types from Transport.
        /// </summary>
        [JsonProperty("deadlineTypes")]
        internal List<string> DeadlineTypes { get; set; }

        /// <summary>
        /// Gets or sets the project description from Transport.
        /// </summary>
        [JsonProperty("notes")]
        internal string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of project files from Transport.
        /// </summary>
        [JsonProperty("folderDetails")]
        internal List<TransportLegacyFolderModel> Files { get; set; }
    }
}
