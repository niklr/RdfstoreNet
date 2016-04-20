using RdfstoreNet.Models.Template;
using System;

namespace RdfstoreNet.Endpoints.Interfaces
{
    public interface ITemplateEndpoint
    {
        TemplateResponseModel CallTemplate(string templateName, params string[] parameters);

        void CallTemplateAsync(string templateName, Action success, Action<RdfstoreException> failure, params string[] parameters);

        void CallTemplateAsync(string templateName, Action<TemplateResponseModel> success, Action<RdfstoreException> failure, params string[] parameters);
    }
}
