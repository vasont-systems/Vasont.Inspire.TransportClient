using System;
using System.Collections.Generic;
using System.Text;

namespace Vasont.Inspire.TransportClient.Models
{
    class TransportProjectModel
    {
        public TransportProjectFoldersModel Folders { get; set; }

        public string Status { get; set; }

        public object Cost { get; set; }

        public double Tax { get; set; }

        public Guid ProjectId { get; set; }

        public object CurrencyCultureInfo { get; set; }

        public object ProjectName { get; set; }

        public object SourceLanguage { get; set; }

        public object TargetLanguages { get; set; }

        public List<string> DeadlineTypes { get; set; }

        public DateTime Deadline { get; set; }

        public double TurnaroundTime { get; set; }

        public bool QuoteRequired { get; set; }

        public object Description { get; set; }

        public List<TransportProjectCustomFieldsModel> CustomFields { get; set; }

        public object ProjectNo { get; set; }

        public object FileChanges { get; set; }
    }
}
