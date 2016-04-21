using RdfstoreNet.RestSharp;
using RestSharp;
using System;
using System.Linq;
using System.Net;

namespace RdfstoreNet
{
    /// <summary>
    /// Passed to each service endpoint class to provide access management. An abstract class is used instead of an interface
    /// to be able to mix internal and public method signatures (we want to expose access information to the consumer of this library, 
    /// but hide the IRequest, RestClient and other low level RestSharp requests associated with the access information.  
    /// Because it's an abstract class it can be mocked easily for testing purposes.
    /// </summary>
    public abstract class AccessManagerBase
    {
        private const string LocationHeaderName = "Location";
        private readonly string _baseUrl;
        private RestClient _client;

        public AccessManagerBase(string baseUrl)
        {
            _baseUrl = baseUrl;

            //Initialize the rest client
            _client = new RestClient();
            _client.ClearHandlers();
            _client.AddHandler("*", new HtmlDeserializer());
        }

        #region Synchronous

        /// <summary>
        /// Synchronous request returning response data as T.
        /// </summary>
        /// <typeparam name="T">The type of the deserialized response data.</typeparam>
        /// <param name="request">The rest request.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response HTTP status code is not as expected.</exception>
        /// <returns>The deserialized response data.</returns>
        internal virtual T Execute<T>(IRestRequest request, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK) where T : new()
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            IRestResponse<T> response = _client.Execute<T>(request);
            if (response.StatusCode == expectedStatusCode)
                return response.Data;
            else
                throw new RdfstoreException(response);
        }

        /// <summary>
        /// Synchronous request. 
        /// </summary>
        /// <param name="request">The rest request.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <param name="expectedStatusCode">The expected HTTP status code.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response HTTP status code is not as expected.</exception>
        internal virtual void Execute(IRestRequest request, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            IRestResponse response = _client.Execute(request);
            if (response.StatusCode != expectedStatusCode)
                throw new RdfstoreException(response);
        }

        /// <summary>
        /// Synchronous request to create a resource.
        /// </summary>
        /// <param name="request">The rest request.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response is not HttpStatusCode.Created.</exception>
        /// <returns>Returns the Location header if present, otherwise returns null.</returns>
        internal virtual string ExecuteCreate(IRestRequest request, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            IRestResponse response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var locationHeader = response.Headers.FirstOrDefault(h => h.Name == LocationHeaderName);
                if (locationHeader == null)
                    return null;
                else
                    return locationHeader.Value as string;
            }
            else
            {
                throw new RdfstoreException(response);
            }
        }

        #endregion

        #region Asynchronous

        /// <summary>
        /// Asynchronous request.  
        /// </summary>
        /// <typeparam name="T">The type of the deserialized response data.</typeparam>
        /// <param name="request">The rest request.</param>
        /// <param name="success">Executed if the returned status code is as expected.</param>
        /// <param name="failure">Executed if the returned status code is not as expected.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <param name="expectedStatusCode">The expected HTTP status code.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response HTTP status code is not as expected.</exception>
        internal virtual void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<RdfstoreException> failure, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK) where T : new()
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            _client.ExecuteAsync<T>(request, (response, asynchandle) =>
            {
                if (response.StatusCode == expectedStatusCode)
                    success(response.Data);
                else
                    failure(new RdfstoreException(response));
            });
        }

        /// <summary>
        /// Asynchronous request.
        /// </summary>
        /// <param name="request">The rest request.</param>
        /// <param name="success">Executed if the returned status code is as expected.</param>
        /// <param name="failure">Executed if the returned status code is not as expected.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <param name="expectedStatusCode">The expected HTTP status code.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response HTTP status code is not as expected.</exception>
        internal virtual void ExecuteAsync(IRestRequest request, Action success, Action<RdfstoreException> failure, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            _client.ExecuteAsync(request, (response, asynchandle) =>
            {
                if (response.StatusCode == expectedStatusCode)
                    success();
                else
                    failure(new RdfstoreException(response));
            });
        }

        /// <summary>
        /// Asynchronous request to create a resource.
        /// </summary>
        /// <param name="request">The rest request.</param>
        /// <param name="success">Executed if response is HttpStatusCode.Created.</param>
        /// <param name="failure">Executed if response is not HttpStatusCode.Created.</param>
        /// <param name="baseUrl">baseUrl is optional and may replace the baseUrl defined in the constructor.</param>
        /// <exception cref="RdfstoreException">Throws a RdfstoreException if response is not HttpStatusCode.Created.</exception>
        internal virtual void ExecuteCreateAsync(IRestRequest request, Action<string> success, Action<RdfstoreException> failure, string baseUrl = null)
        {
            if (string.IsNullOrEmpty(baseUrl))
                _client.BaseUrl = new Uri(_baseUrl);
            else
                _client.BaseUrl = new Uri(baseUrl);

            _client.ExecuteAsync(request, (response, asynchandle) =>
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    string locationHeaderValue = null;
                    var locationHeader = response.Headers.Where(h => h.Name == LocationHeaderName).FirstOrDefault();
                    if (locationHeader != null)
                    {
                        locationHeaderValue = locationHeader.Value as string;
                    }
                    success(locationHeaderValue);
                }
                else
                {
                    failure(new RdfstoreException(response));
                }
            });
        }

        #endregion
    }
}
