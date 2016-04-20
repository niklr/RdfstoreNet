using RdfstoreNet.Endpoints.Interfaces;
using System;
using RdfstoreNet.Models.Template;
using RestSharp;
using RdfstoreNet.Helpers;

namespace RdfstoreNet.Endpoints
{
    public class TemplateEndpoint : ITemplateEndpoint
    {
        private readonly AccessManagerBase _accessManager;

        public TemplateEndpoint(AccessManagerBase accessManager)
        {
            _accessManager = accessManager;
        }

        public TemplateResponseModel CallTemplate(string templateName, params string[] parameters)
        {
            return _accessManager.Execute<TemplateResponseModel>(PrepareRequest(templateName, parameters));
        }

        public void CallTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PrepareRequest(templateName, parameters), success, failure);
        }

        public void CallTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PrepareRequest(templateName, parameters), success, failure);
        }

        private IRestRequest PrepareRequest(string path, params string[] parameters)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = string.Format("{0}/?{1}", path, QueryBuilder.Build(false, parameters));
            return request;
        }
    }
}
