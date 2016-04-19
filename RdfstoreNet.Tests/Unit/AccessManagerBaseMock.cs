using RestSharp;
using System;
using System.Net;

namespace RdfstoreNet.Tests.Unit
{
    /// <summary>
    /// Mocking the actual RestSharp request execution. 
    /// Overriding internals in a different assembly thanks to the InternalsVisibleTo attribute.
    /// </summary>
    public abstract class AccessManagerBaseMock : AccessManagerBase
    {
        public AccessManagerBaseMock(string baseUrl) : base(baseUrl)
        {

        }

        internal override T Execute<T>(IRestRequest request, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            return new T();
        }

        internal override void Execute(IRestRequest request, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
        }

        internal override string ExecuteCreate(IRestRequest request, string baseUrl = null)
        {
            return string.Empty;
        }

        internal override void ExecuteAsync<T>(IRestRequest request, Action<T> success, Action<RdfstoreException> failure, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
        }

        internal override void ExecuteAsync(IRestRequest request, Action success, Action<RdfstoreException> failure, string baseUrl = null, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
        }

        internal override void ExecuteCreateAsync(IRestRequest request, Action<string> success, Action<RdfstoreException> failure, string baseUrl = null)
        {
        }
    }
}
