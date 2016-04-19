using Newtonsoft.Json;
using RestSharp.Serializers;

namespace RdfstoreNet.RestSharp
{
    /// <summary>
    /// Serializer that ignores null values when serializing.
    /// The built-in RestSharp serializer is unable to ignore null properties when serializing.
    /// </summary>
    public class JsonNETSerializer : ISerializer
    {
		public JsonNETSerializer()
        {
            ContentType = "application/json";
        }

        #region ISerializer

		public string Serialize(object obj)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSettings);
        }

        public string DateFormat { get; set; }

        public string RootElement { get; set; }

        public string Namespace { get; set; }

        public string ContentType { get; set; }

        #endregion
    }
}
