//-----------------------------------------------------------------------
// <copyright file="TransportConfigurationModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Settings
{
    /// <summary>
    /// This class represents the <see cref="TransportConfigurationModel"/> object that is used with the Transport Integration.
    /// </summary>
    /// <seealso cref="Vasont.Inspire.Api.Core.Translations.Models.BaseConfigurationModel" />
    public class TransportConfigurationModel : BaseConfigurationModel
    {
        /// <summary>
        /// Gets or sets the default project identifier.
        /// </summary>
        /// <value>
        /// The default project identifier.
        /// </value>
        public long DefaultProjectId { get; set; }
    }
}
