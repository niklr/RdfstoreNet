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

        public TemplateResponseModel GetTemplate(string templateName, params string[] parameters)
        {
            return _accessManager.Execute<TemplateResponseModel>(PrepareGetRequest(templateName, parameters));
        }

        public void GetTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PrepareGetRequest(templateName, parameters), success, failure);
        }

        public void GetTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PrepareGetRequest(templateName, parameters), success, failure);
        }

        public TemplateResponseModel PostTemplate(string templateName, params string[] parameters)
        {
            return _accessManager.Execute<TemplateResponseModel>(PreparePostRequest(templateName, parameters));
        }

        public void PostTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PreparePostRequest(templateName, parameters), success, failure);
        }

        public void PostTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters)
        {
            _accessManager.ExecuteAsync(PreparePostRequest(templateName, parameters), success, failure);
        }

        private IRestRequest PrepareGetRequest(string path, params string[] parameters)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = string.Format("{0}/?{1}", path, QueryBuilder.Build(false, parameters));
            return request;
        }

        private IRestRequest PreparePostRequest(string path, params string[] parameters)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = string.Format("{0}/", path);
            if (parameters != null && parameters.Length > 0)
                request.AddParameter("text/plain", QueryBuilder.Build(false, parameters), ParameterType.RequestBody);
            return request;
        }
    }
}
