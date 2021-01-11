//-----------------------------------------------------------------------
// <copyright file="TransportProjectFoldersModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models.Internal
{
    using Newtonsoft.Json;

    /// <summary>
    /// This class represents the <see cref="TransportProjectFoldersModel"/> that's referenced in the <see cref="TransportProjectTemplateModel"/>.
    /// </summary>
    internal class TransportProjectFoldersModel
    {
        [JsonProperty("sourceFiles")]
        internal string SourceFiles { get; set; }

        [JsonProperty("referenceFiles")]
        internal string ReferenceFiles { get; set; }

        [JsonProperty("deliverableFiles")]
        internal string DeliverableFiles { get; set; }

        [JsonProperty("quoteFiles")]
        internal string QuoteFiles { get; set; }
    }
}
