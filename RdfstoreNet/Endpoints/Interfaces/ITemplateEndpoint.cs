using RdfstoreNet.Models.Template;
using System;

namespace RdfstoreNet.Endpoints.Interfaces
{
    public interface ITemplateEndpoint
    {
        TemplateResponseModel GetTemplate(string templateName, params string[] parameters);

        void GetTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters);

        void GetTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters);

        TemplateResponseModel PostTemplate(string templateName, params string[] parameters);

        void PostTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters);

        void PostTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters);

    }
}
