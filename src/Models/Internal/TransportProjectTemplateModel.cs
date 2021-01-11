//-----------------------------------------------------------------------
// <copyright file="TransportProjectTemplateModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportProjectTemplateModel"/> that's used to create a project on Transport.
    /// </summary>
    internal class TransportProjectTemplateModel
    {
        internal TransportProjectTemplateModel()
        {
            this.TargetLanguages = new List<string>();
            this.DeadlineTypes = new List<string>();
        }

        /// <summary>
        /// Gets or sets the folder identifiers that were created as part of the project template creation on the Transport side.
        /// </summary>
        [JsonProperty("folders")]
        internal TransportProjectFoldersModel Folders { get; set; }

        /// <summary>
        /// Gets or sets the status information from the project template from Transport.
        /// </summary>
        [JsonProperty("status")]
        internal string Status { get; set; }

        /// <summary>
        /// Gets or sets the cost information from the project template from Transport.
        /// </summary>
        [JsonProperty("cost")]
        internal string Cost { get; set; }

        /// <summary>
        /// Gets or sets the tax information from the project template from Transport.
        /// </summary>
        [JsonProperty("tax")]
        internal float Tax { get; set; }

        /// <summary>
        /// Gets or sets the project identifier information from the project template from Transport.
        /// </summary>
        [JsonProperty("projectId")]
        internal string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the currency culture information from the project template from Transport.
        /// </summary>
        [JsonProperty("currenctCultureInfo")]
        internal string CurrencyCultureInfo { get; set; }

        /// <summary>
        /// Gets or sets the project name information from the project template from Transport.
        /// </summary>
        [JsonProperty("projectName")]
        internal string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the source language information from the project template from Transport.
        /// </summary>
        [JsonProperty("sourceLanguage")]
        internal string SourceLanguage { get; set; }

        /// <summary>
        /// Gets or sets a list of target languages from the project template from Transport.
        /// </summary>
        [JsonProperty("targetLanguages")]
        internal List<string> TargetLanguages { get; set; }

        /// <summary>
        /// Gets or sets a list of deadline types from the project template from Transport.
        /// </summary>
        [JsonProperty("deadlineTypes")]
        internal List<string> DeadlineTypes { get; set; }

        /// <summary>
        /// Gets or sets the deadline information from the project template from Transport.
        /// </summary>
        [JsonProperty("deadline")]
        internal DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the turnaround time information from the project template from Transport.
        /// </summary>
        [JsonProperty("turnaroundTime")]
        internal float TurnAroundTime { get; set; }

        /// <summary>
        /// Gets or sets whether quote is required for this project from the project template from Transport.
        /// </summary>
        [JsonProperty("quoteRequired")]
        internal bool QuoteRequired { get; set; }

        /// <summary>
        /// Gets or sets the project description information from the project template from Transport.
        /// </summary>
        [JsonProperty("description")]
        internal string Description { get; set; }

        /// <summary>
        /// Gets or sets a list of custom fields from the project template from Transport.
        /// </summary>
        [JsonProperty("customFields")]
        internal Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the project number information from the project template from Transport.
        /// </summary>
        [JsonProperty("projectNo")]
        internal string TransportProjectNumber { get; set; }

        /// <summary>
        /// Gets or sets the file changes information from the project template from Transport.
        /// </summary>
        [JsonProperty("fileChanges")]
        internal string FileChanges { get; set; }
    }
}
