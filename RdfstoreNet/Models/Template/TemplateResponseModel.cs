using System.Collections.Generic;

namespace RdfstoreNet.Models.Template
{
    public class TemplateResponseModel
    {
        public string Content { get; set; }

        public List<string[]> Results { get; set; }

        public TemplateResponseModel()
        {
            Results = new List<string[]>();
        }
    }
}
