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

        /// <summary>
        /// Gets or sets the project identifier inforamtion from Transport.
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the Tranport project identifier inforamtion from Transport.
        /// </summary>
        public string TransportProjectNumber { get; set; }

        /// <summary>
        /// Gets or sets the submission request payload that was sent to Transport.
        /// </summary>
        public string SubmissionRequest { get; set; }

        /// <summary>
        /// Gets or sets the submission response received from Transport.
        /// </summary>
        public string SubmissionResponse { get; set; }
    }
}
