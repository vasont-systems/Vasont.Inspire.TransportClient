
namespace Vasont.Inspire.TransportClient.Models
{
    using System;
    using System.Collections.Generic;

    public class TransportProjectCreateModel
    {
        public TransportProjectCreateModel()
        {
            this.TargetLanguages = new List<string>();
            this.DeadlineTypes = new List<string>();
        }

        public string ProjectName { get; set; }

        public string SourceLanguage { get; set; }

        public List<string> TargetLanguages { get; set; }

        public List<string> DeadlineTypes { get; set; }

        public DateTime Deadline { get; set; }

        public bool QuoteRequired { get; set; }

        public string Description { get; set; }

        public List<KeyValuePair<string, string>> CustomFields { get; set; }
    }
}
