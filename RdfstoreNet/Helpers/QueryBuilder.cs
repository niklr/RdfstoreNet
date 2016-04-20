using System.Collections.Specialized;
using System.Web;

namespace RdfstoreNet.Helpers
{
    public static class QueryBuilder
    {
        /// <summary>
        /// Builds a query string of the form 0=param0&1=param1&2=param2 etc.
        /// </summary>
        /// <param name="urlEncode">Url encode the query.</param>
        /// <param name="parameters">The parameters to be used in the query.</param>
        /// <returns>A query string of the form 0=param0&1=param1&2=param2 etc.</returns>
        public static string Build(bool urlEncode, params string[] parameters)
        {
            if (parameters == null) return string.Empty;

            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

            for (int i = 0; i < parameters.Length; i++)
                query[i.ToString()] = parameters[i];

            if (urlEncode)
                return query.ToString();
            else
                return HttpUtility.UrlDecode(query.ToString());
        }
    }
}
