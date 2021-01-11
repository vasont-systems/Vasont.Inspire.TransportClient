using System;
using System.Collections.Generic;
using System.Text;

namespace Vasont.Inspire.TransportClient.Models.Internal
{
    internal class TransportProjectModel
    {
        internal TransportProjectFoldersModel Folders { get; set; }

        internal string Status { get; set; }

        internal object Cost { get; set; }

        internal double Tax { get; set; }

        internal Guid ProjectId { get; set; }

        internal object CurrencyCultureInfo { get; set; }

        internal object ProjectName { get; set; }

        internal object SourceLanguage { get; set; }

        internal object TargetLanguages { get; set; }

        internal List<string> DeadlineTypes { get; set; }

        internal DateTime Deadline { get; set; }

        internal double TurnaroundTime { get; set; }

        internal bool QuoteRequired { get; set; }

        internal object Description { get; set; }

        internal List<TransportProjectCustomFieldsModel> CustomFields { get; set; }

        internal object ProjectNo { get; set; }

        internal object FileChanges { get; set; }
    }
}
