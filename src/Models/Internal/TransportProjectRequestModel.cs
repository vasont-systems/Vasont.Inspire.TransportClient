//-----------------------------------------------------------------------
// <copyright file="TransportProjectRequestModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    internal class TransportProjectRequestModel
    {
        public TransportProjectRequestModel()
        {
            this.TargetLanguages = new List<string>();
            this.DeadlineTypes = new List<string>();
            this.CustomFields = new Dictionary<string, string>();
            this.Files = new List<TransportProjectFileModel>();
        }

        /// <summary>
        /// Gets or sets the project identifier value from the project template from Transport.
        /// </summary>
        internal Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("projectName")]
        internal string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the source language for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("sourceLanguage")]
        internal string SourceLanguage { get; set; }

        /// <summary>
        /// Gets or sets a list of target languages for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("targetLanguages")]
        internal List<string> TargetLanguages { get; set; }

        /// <summary>
        /// Gets or sets a list of deadline types for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("deadlineTypes")]
        internal List<string> DeadlineTypes { get; set; }

        /// <summary>
        /// Gets or sets the turnaround time value for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("turnaroundTime")]
        internal float TurnaroundTime { get; set; }

        /// <summary>
        /// Gets or sets whether a quote is required or not for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("quoteRequired")]
        internal bool QuoteRequired { get; set; }

        /// <summary>
        /// Gets or sets the project description for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("description")]
        internal string Description { get; set; }

        /// <summary>
        /// Gets or sets a list of custom fields for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("customFields")]
        internal Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets a list of project files for the project that should be created on Transport.
        /// </summary>
        [JsonProperty("fileChanges")]
        internal List<TransportProjectFileModel> Files { get; set; }
    }
}
