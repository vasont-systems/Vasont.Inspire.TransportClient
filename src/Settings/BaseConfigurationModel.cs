//-----------------------------------------------------------------------
// <copyright file="BaseConfigurationModel.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient.Settings
{
    using System;

    /// <summary>
    /// Contains an enumerated list of SDK client authentication methods.
    /// </summary>
    public enum ClientAuthenticationMethods
    {
        /// <summary>
        /// The client shall authenticate with a client secret.
        /// </summary>
        ClientCredentials,

        /// <summary>
        /// The client shall authenticate with the resource owner using a user id and password.
        /// </summary>
        /// <remarks>
        /// The spec recommends using the resource owner password grant only for "trusted" (or legacy) applications.
        /// </remarks>
        ResourceOwnerPassword,

        /// <summary>
        /// This method shall allow a client token to be exchanged for another from the authority for client delegation with another API.
        /// </summary>
        Delegation
    }

    /// <summary>
    /// This class represents the <see cref="BaseConfigurationModel"/> used to establish a connection to the identity server.
    /// </summary>
    public class BaseConfigurationModel
    {
        /// <summary>
        /// Gets or sets the client authentication method used.
        /// </summary>
        public ClientAuthenticationMethods AuthenticationMethod { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        /// <value>
        /// The resource URI.
        /// </value>
        public Uri ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the Authority URI.
        /// </summary>
        /// <value>
        /// The Authority URI.
        /// </value>
        public Uri AuthorityUri { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the authority discovery endpoint will be used for token endpoint lookup.
        /// </summary>
        public bool UseDiscovery { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the list of target resource scopes.
        /// </summary>
        public string[] TargetResourceScopes { get; set; }

        /// <summary>
        /// Gets or sets the type of the grant.
        /// </summary>
        /// <value>
        /// The type of the grant.
        /// </value>
        public string GrantType { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        /// <value>
        /// The secret.
        /// </value>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the client access token.
        /// </summary>
        /// <value>
        /// The client access token.
        /// </value>
        public string DelegatedAccessToken { get; set; }

        /// <summary>
        /// Gets or sets an optional URI route prefix to add to all requests. 
        /// </summary>
        public string RoutePrefix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [include basic authentication header].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [include basic authentication header]; otherwise, <c>false</c>.
        /// </value>
        public bool IncludeBasicAuthenticationHeader { get; set; }
    }
}
