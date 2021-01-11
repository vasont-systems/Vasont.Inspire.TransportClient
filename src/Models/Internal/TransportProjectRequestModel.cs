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
            this.Files = new List<TransportProjectFilesModel>();
        }

        internal Guid ProjectId { get; set; }

        [JsonProperty("projectName")]
        internal string ProjectName { get; set; }

        [JsonProperty("sourceLanguage")]
        internal string SourceLanguage { get; set; }

        [JsonProperty("targetLanguages")]
        internal List<string> TargetLanguages { get; set; }

        [JsonProperty("deadlineTypes")]
        internal List<string> DeadlineTypes { get; set; }

        [JsonProperty("turnaroundTime")]
        internal float TurnaroundTime { get; set; }

        [JsonProperty("quoteRequired")]
        internal bool QuoteRequired { get; set; }

        [JsonProperty("description")]
        internal string Description { get; set; }

        [JsonProperty("customFields")]
        internal Dictionary<string, string> CustomFields { get; set; }

        [JsonProperty("fileChanges")]
        internal List<TransportProjectFilesModel> Files { get; set; }
    }
}
