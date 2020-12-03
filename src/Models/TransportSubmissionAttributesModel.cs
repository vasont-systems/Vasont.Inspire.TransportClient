//-----------------------------------------------------------------------
// <copyright file="TransportSubmissionAttributesModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient
{
    using System.Collections.Generic;

    public class TransportSubmissionAttributesModel
    {
        public TransportSubmissionAttributesModel()
        {
            this.CustomFields = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Gets or sets the selected project identifier.
        /// </summary>
        /// <value>
        /// The selected project identifier.
        /// </value>
        public long ProjectId { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        /// <summary>
        /// Gets or sets the custom fields.
        /// </summary>
        /// <value>
        /// The custom fields.
        /// </value>
        public List<KeyValuePair<string, string>> CustomFields { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
