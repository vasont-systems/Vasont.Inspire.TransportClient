//-----------------------------------------------------------------------
// <copyright file="TransportProjectFolderModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportProjectFolderModel"/> that's referenced in the <see cref="TransportProjectTemplateModel"/>.
    /// </summary>
    internal class TransportProjectFolderModel
    {
        /// <summary>
        /// Gets or sets the identifier of the source folder that's created as part of the project template from Transport.
        /// </summary>
        [JsonProperty("sourceFiles")]
        internal string SourceFiles { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the reference files folder that's created as part of the project template from Transport.
        /// </summary>
        [JsonProperty("referenceFiles")]
        internal string ReferenceFiles { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the deliverable files folder that's created as part of the project template from Transport.
        /// </summary>
        [JsonProperty("deliverableFiles")]
        internal string DeliverableFiles { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the quote files folder that's created as part of the project template from Transport.
        /// </summary>
        [JsonProperty("quoteFiles")]
        internal string QuoteFiles { get; set; }
    }
}
