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

        [JsonProperty("folders")]
        internal TransportProjectFoldersModel Folders { get; set; }

        [JsonProperty("status")]
        internal string Status { get; set; }

        [JsonProperty("cost")]
        internal string Cost { get; set; }

        [JsonProperty("tax")]
        internal float Tax { get; set; }

        [JsonProperty("projectId")]
        internal string ProjectId { get; set; }

        [JsonProperty("currenctCultureInfo")]
        internal string CurrencyCultureInfo { get; set; }

        [JsonProperty("projectName")]
        internal string ProjectName { get; set; }

        [JsonProperty("sourceLanguage")]
        internal string SourceLanguage { get; set; }

        [JsonProperty("targetLanguages")]
        internal List<string> TargetLanguages { get; set; }

        [JsonProperty("deadlineTypes")]
        internal List<string> DeadlineTypes { get; set; }

        [JsonProperty("deadline")]
        internal DateTime Deadline { get; set; }

        [JsonProperty("turnaroundTime")]
        internal float TurnAroundTime { get; set; }

        [JsonProperty("quoteRequired")]
        internal bool QuoteRequired { get; set; }

        [JsonProperty("description")]
        internal string Description { get; set; }

        [JsonProperty("customFields")]
        internal Dictionary<string, string> CustomFields { get; set; }

        [JsonProperty("projectNo")]
        internal string TransportProjectNumber { get; set; }

        [JsonProperty("fileChanges")]
        internal string FileChanges { get; set; }
    }
}
