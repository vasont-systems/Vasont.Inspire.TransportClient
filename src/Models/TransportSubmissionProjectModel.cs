//-----------------------------------------------------------------------
// <copyright file="TransportProjectSubmissionModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportSubmissionProjectModel"/> that's used by the consuming client 
    /// to send across the info needed to submit a project request to Transport.
    /// </summary>
    public class TransportSubmissionProjectModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportSubmissionProjectModel" /> class.
        /// </summary>
        public TransportSubmissionProjectModel()
        {
            this.TargetLanguages = new List<string>();
            this.CustomFields = new Dictionary<string, string>();
            this.FilesToUpload = new List<TransportSubmissionProjectFileModel>();
        }

        /// <summary>
        /// Gets or sets the project identifier inforamtion for Transport.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name for Transport.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the source language for Transport.
        /// </summary>
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Gets or sets a list of target languages for Transport.
        /// </summary>
        public List<string> TargetLanguages { get; set; }

        /// <summary>
        /// Gets or sets the project description for Transport.
        /// </summary>
        public string ProjectDescription { get; set; }

        /// <summary>
        /// Gets or sets a list of custom fields for Transport.
        /// </summary>
        public Dictionary<string, string> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets a list of file to upload to Transport.
        /// </summary>
        public List<TransportSubmissionProjectFileModel> FilesToUpload { get; set; }
    }
}
