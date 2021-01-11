//-----------------------------------------------------------------------
// <copyright file="TransportSubmissionResponseModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    /// <summary>
    /// This class represents the <see cref="TransportSubmissionResponseModel"/> that carries the response info after creating a Transport project.
    /// </summary>
    public class TransportSubmissionResponseModel
    {
        internal TransportSubmissionResponseModel()
        {
        }

        public string ProjectId { get; set; }

        public string TransportProjectNumber { get; set; }

        public string SubmissionRequest { get; set; }

        public string SubmissionResponse { get; set; }
    }
}
