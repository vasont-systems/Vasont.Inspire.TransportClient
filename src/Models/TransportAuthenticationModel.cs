//-----------------------------------------------------------------------
// <copyright file="TransportAuthenticationModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Models
{
    /// <summary>
    /// This class represents the <see cref="TransportAuthenticationModel"/> that's used by the consuming client 
    /// to send across the authentication info needed to connect to Transport.
    /// </summary>
    public class TransportAuthenticationModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransportAuthenticationModel" /> class.
        /// </summary>
        public TransportAuthenticationModel()
        {
        }

        /// <summary>
        /// Gets or sets the Transport endpoint URL.
        /// </summary>
        public string RESTUrl { get; set; }

        /// <summary>
        /// Gets or sets the route prefix information if it's used.
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// Gets or sets the authority endpoint for authentication.
        /// </summary>
        public string AuthorityUri { get; set; }

        /// <summary>
        /// Gets or sets the username inforamtion for authentication
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password inforamtion for authentication
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the client identifier inforamtion for authentication
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret inforamtion for authentication
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets a list of client scopes for authentication
        /// </summary>
        public string ClientScopes { get; set; }

        /// <summary>
        /// Gets or sets the grant type inforamtion for authentication
        /// </summary>
        public string GrantType { get; set; }
    }
}
