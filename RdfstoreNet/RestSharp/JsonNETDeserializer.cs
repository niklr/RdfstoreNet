using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace RdfstoreNet.RestSharp
{
    /// <summary>
    /// Serializer that converts Utc to localtime automatically.
    /// The built-in RestSharp de-serializer doesn't convert Utc to localtime automatically.
    /// </summary>
    public class JsonNETDeserializer : IDeserializer
    {
        #region IDeserializer

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string DateFormat { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<T>(response.Content, jsonSettings);
        }

        #endregion
    }
}
