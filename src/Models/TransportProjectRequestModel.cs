using System;
using System.Collections.Generic;
using System.Text;

namespace Vasont.Inspire.TransportClient.Models
{
    public class TransportProjectRequestModel
    {
        public Guid ProjectId { get; set; }

        public TransportProjectCreateModel Model { get; set; }
    }
}
