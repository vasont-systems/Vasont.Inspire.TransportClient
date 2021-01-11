//-----------------------------------------------------------------------
// <copyright file="TransportProjectSubmissionModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportSubmissionProjectModel"/> that's used by the consuming client 
    /// to send across the info needed to submit a project request to Transport.
    /// </summary>
    public class TransportSubmissionProjectModel
    {
        public TransportSubmissionProjectModel()
        {
            this.TargetLanguages = new List<string>();
            this.CustomFields = new Dictionary<string, string>();
            this.FilesToUpload = new List<TransportSubmissionProjectFileModel>();
        }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string SourceLanguage { get; set; }

        public List<string> TargetLanguages { get; set; }

        public string ProjectDescription { get; set; }

        public Dictionary<string, string> CustomFields { get; set; }

        public List<TransportSubmissionProjectFileModel> FilesToUpload { get; set; }
    }
}
