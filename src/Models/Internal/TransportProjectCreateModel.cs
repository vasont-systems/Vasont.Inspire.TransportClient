////-----------------------------------------------------------------------
//// <copyright file="TransportProjectCreateModel.cs" company="GlobalLink Vasont">
//// Copyright (c) GlobalLink Vasont. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
//namespace Vasont.Inspire.TransportClient.Models
//{
//    using Newtonsoft.Json;
//    using System.Collections.Generic;

//    /// <summary>
//    /// This class represents the <see cref="TransportProjectCreateModel"/> that's used when submitting a new project.
//    /// </summary>
//    class TransportProjectCreateModel
//    {
//        public TransportProjectCreateModel()
//        {
//            this.TargetLanguages = new List<string>();
//            this.DeadlineTypes = new List<string>();
//            this.CustomFields = new Dictionary<string, string>();
//            this.Files = new List<TransportProjectFilesModel>();
//        }

//        [JsonProperty("projectName")]
//        public string ProjectName { get; set; }

//        [JsonProperty("sourceLanguage")]
//        public string SourceLanguage { get; set; }

//        [JsonProperty("targetLanguages")]
//        public List<string> TargetLanguages { get; set; }

//        [JsonProperty("deadlineTypes")]
//        public List<string> DeadlineTypes { get; set; }

//        [JsonProperty("turnaroundTime")]
//        public float TurnaroundTime { get; set; }

//        [JsonProperty("quoteRequired")]
//        public bool QuoteRequired { get; set; }

//        [JsonProperty("description")]
//        public string Description { get; set; }

//        [JsonProperty("customFields")]
//        public Dictionary<string, string> CustomFields { get; set; }

//        [JsonProperty("fileChanges")]
//        public List<TransportProjectFilesModel> Files { get; set; }
//    }
//}
