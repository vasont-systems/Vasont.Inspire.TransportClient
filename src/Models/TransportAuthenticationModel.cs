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
        public TransportAuthenticationModel()
        {
        }

        public string RESTUrl { get; set; }

        public string RoutePrefix { get; set; }

        public string AuthorityUri { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ClientScopes { get; set; }

        public string GrantType { get; set; }
    }
}
