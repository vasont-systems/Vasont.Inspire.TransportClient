//-------------------------------------------------------------
// <copyright file="ClientException.cs" company="Vasont Systems">
// Copyright (c) Vasont Systems. All rights reserved.
// </copyright>
//-------------------------------------------------------------
namespace Vasont.Inspire.TransportClient
{
    using System;
    using Vasont.Inspire.TransportClient.Settings;

    /// <summary>
    /// This class extends the default client exception to include additional configuration detail.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class ClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientException" /> class.
        /// </summary>
        public ClientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientException" /> class.
        /// </summary>
        /// <param name="config">Contains the optional transport client configuration settings.</param>
        /// <param name="message">Contains a message.</param>
        /// <param name="innerException">Contains an optional inner exception.</param>
        public ClientException(TransportConfigurationModel config, string message = "", Exception innerException = null)
            : base(message, innerException)
        {
            this.ClientConfiguration = config;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ClientException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the client configuration settings.
        /// </summary>
        /// <value>
        /// The client configuration.
        /// </value>
        public TransportConfigurationModel ClientConfiguration { get; }
    }
}
