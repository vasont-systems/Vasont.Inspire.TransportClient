//-----------------------------------------------------------------------
// <copyright file="TransportSubmissionProjectFileModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Vasont.Inspire.TransportClient.Models
{
    /// <summary>
    /// This class represents the <see cref="TransportSubmissionProjectFileModel"/> that's used to represent a project file.
    /// </summary>
    public class TransportSubmissionProjectFileModel
    {
        public string FilePath { get; set; }

        public byte[] FileStream { get; set; }
    }
}
