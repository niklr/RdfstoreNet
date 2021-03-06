﻿using RestSharp.Deserializers;
using System;
using RestSharp;
using RdfstoreNet.Models.Template;
using System.Web;
using System.Linq;

namespace RdfstoreNet.RestSharp
{
    public class HtmlDeserializer : IDeserializer
    {
        #region IDeserializer

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            Type type = typeof(T);

            if (type == typeof(TemplateResponseModel))
            {
                TemplateResponseModel model = new TemplateResponseModel();
                model.Content = HttpUtility.HtmlDecode(response.Content);

                if (model.Content.StartsWith("<pre>"))
                {
                    if (!model.Content.StartsWith("<pre><html>"))
                    {
                        string[] resultRows = model.Content.Split('\n');
                        resultRows = resultRows.Skip(1).Take(resultRows.Length - 2).ToArray();
                        foreach (string row in resultRows)
                            model.Results.Add(row.Split('\t'));
                    }
                }

                return (T)(object)model;
            }
            else
            {
                return (T)Activator.CreateInstance(type);
            }
        }

        #endregion
    }
}
