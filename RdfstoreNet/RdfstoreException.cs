using RestSharp;
using System;
using System.Net;

namespace RdfstoreNet
{
    public class RdfstoreException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IRestResponse Response { get; private set; }

        public RdfstoreException()
        {
        }

        public RdfstoreException(string message) : base(message)
        {
        }

        public RdfstoreException(IRestResponse response) : base(response.ErrorMessage)
        {
            StatusCode = response.StatusCode;
            Response = response;
        }
    }
}
