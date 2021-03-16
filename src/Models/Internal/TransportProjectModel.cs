//-----------------------------------------------------------------------
// <copyright file="TransportProjectModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class represents the <see cref="TransportProjectModel"/> that represents a Transport project.
    /// </summary>
    internal class TransportProjectModel
    {
        /// <summary>
        /// Gets or sets the folders that are created as part of the project template from Transport.
        /// </summary>
        internal TransportProjectFolderModel Folders { get; set; }

        /// <summary>
        /// Gets or sets the status of the project that's created as part of the project template from Transport.
        /// </summary>
        internal string Status { get; set; }

        /// <summary>
        /// Gets or sets the cost value from the project template from Transport.
        /// </summary>
        internal object Cost { get; set; }

        /// <summary>
        /// Gets or sets the tax value from the project template from Transport.
        /// </summary>
        internal double Tax { get; set; }

        /// <summary>
        /// Gets or sets the project identifier from the project template from Transport.
        /// </summary>
        internal Guid ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the currency culture info from the project template from Transport.
        /// </summary>
        internal object CurrencyCultureInfo { get; set; }

        /// <summary>
        /// Gets or sets the project name from the project template from Transport.
        /// </summary>
        internal object ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the source language from the project template from Transport.
        /// </summary>
        internal object SourceLanguage { get; set; }

        /// <summary>
        /// Gets or sets the list of target languages from the project template from Transport.
        /// </summary>
        internal object TargetLanguages { get; set; }

        /// <summary>
        /// Gets or sets the list of deadline types from the project template from Transport.
        /// </summary>
        internal List<string> DeadlineTypes { get; set; }

        /// <summary>
        /// Gets or sets the deadline date time from the project template from Transport.
        /// </summary>
        internal DateTime Deadline { get; set; }

        /// <summary>
        /// Gets or sets the turnaround time value from the project template from Transport.
        /// </summary>
        internal double TurnaroundTime { get; set; }

        /// <summary>
        /// Gets or sets the whether a quote is required or not from the project template from Transport.
        /// </summary>
        internal bool QuoteRequired { get; set; }

        /// <summary>
        /// Gets or sets the project description from the project template from Transport.
        /// </summary>
        internal object Description { get; set; }

        /// <summary>
        /// Gets or sets a list of custom fields from the project template from Transport.
        /// </summary>
        internal List<TransportProjectCustomFieldModel> CustomFields { get; set; }

        /// <summary>
        /// Gets or sets the project number from the project template from Transport.
        /// </summary>
        internal object ProjectNo { get; set; }

        /// <summary>
        /// Gets or sets the file changes value from the project template from Transport.
        /// </summary>
        internal object FileChanges { get; set; }
    }
}
