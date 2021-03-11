//-----------------------------------------------------------------------
// <copyright file="TransportProjectCustomFieldModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    /// <summary>
    /// This class represents the <see cref="TransportProjectCustomFieldModel"/> that represents a custom field on a Transport project.
    /// </summary>
    internal class TransportProjectCustomFieldModel
    {
        /// <summary>
        /// Gets or sets the name of the custom field.
        /// </summary>
        /// <value>
        /// The name of the custom field.
        /// </value>
        public string CustomFieldName { get; set; }

        /// <summary>
        /// Gets or sets the custom field value.
        /// </summary>
        /// <value>
        /// The custom field value.
        /// </value>
        public string CustomFieldValue { get; set; }
    }
}
