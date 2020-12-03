//-----------------------------------------------------------------------
// <copyright file="TransportClient.cs" company="GlobalLink Vasont">
// Copyright (c) GlobalLink Vasont. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Vasont.Inspire.TransportClient
{
    using System;
    using System.IO;
    using System.IO.Enumeration;
    using System.Net;
    using System.Net.Cache;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using IdentityModel.Client;
    using Newtonsoft.Json;
    using Vasont.Inspire.Core.Errors;
    using Vasont.Inspire.Models.Common;
    using Vasont.Inspire.TransportClient.Extensions;
    using Vasont.Inspire.TransportClient.Models;
    using Vasont.Inspire.TransportClient.Properties;
    using Vasont.Inspire.TransportClient.Settings;

    public class TransportClient : BaseClient
    {
        public TransportClient(TransportConfigurationModel configurationModel)
            : base(configurationModel)
        {
        }

        public async Task<bool> RetrieveProjectTempaltesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                // GET api/v2/projects/template
                var request = this.CreateRequest($"/projects/template");
                
                // TODO create response model
                this.RequestContent<string>(request);
            }

            return true;
        }

        public async Task<bool> CreateProjectAsync(TransportProjectRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                var request = this.CreateRequest($"/projects/{requestModel.ProjectId}", HttpMethod.Post);

                // TODO create response model
                this.RequestContent<TransportProjectCreateModel, string>(request, requestModel.Model);
            }

            return true;
        }

        public async Task<bool> UpdateProjectAsync(TransportProjectRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                var request = this.CreateRequest($"/projects/{requestModel.ProjectId}", HttpMethod.Put);

                // TODO create response model
                this.RequestContent<TransportProjectCreateModel, string>(request, requestModel.Model);
            }

            return true;
        }

        public async Task<bool> FindProjectAsync(Guid projectTemplateId, CancellationToken cancellationToken = default(CancellationToken))
        {            
            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                var request = this.CreateRequest($"/projects/{projectTemplateId}", HttpMethod.Post);

                // TODO create response model
                this.RequestContent<string>(request);
            }
            return true;
        }

        public async Task<bool> UploadFilesAsync(TransportFileUploadRequestModel requestModel, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Post /files/upload

            // If we're not authenticated then call the Authenticate method
            if (!this.HasAuthenticated)
            {
                await this.AuthenticateAsync(string.Empty, cancellationToken).ConfigureAwait(false);
            }

            // Once we've successfully authenticated call the Api endpoint to get project templates using the token response.
            if (this.HasAuthenticated)
            {
                var request = this.CreateRequest($"/files/upload?filename={requestModel.FilePath}&targetFolderId={requestModel.TargetFolderId}&saveToProject={requestModel.SaveToProject}", HttpMethod.Post);

                // write data out to the request stream
                using (var postStream = request.GetRequestStream())
                {
                    postStream.WriteMultiPartFormData(requestModel);
                }

                // TODO create response model
                this.RequestContent<string>(request);
            }
            return true;
        }
    }
}
