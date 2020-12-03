using System;
using System.Collections.Generic;
using System.Text;

namespace Vasont.Inspire.TransportClient.Models
{
    public class TransportFileUploadRequestModel
    {
        public string FilePath { get; set; }

        public Guid TargetFolderId { get; set; }

        public bool SaveToProject { get; set; }
    }
}
