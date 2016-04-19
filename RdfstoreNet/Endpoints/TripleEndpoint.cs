using System;
using RdfstoreNet.Endpoints.Interfaces;
using RestSharp;
using RdfstoreNet.Models.Triple;

namespace RdfstoreNet.Endpoints
{
    public class TripleEndpoint : ITripleEndpoint
    {
        private const string CreateTriplePath = "Insert_Triple_(Fuseki)";
        private const string DeleteTriplePath = "Delete_Triple_(Fuseki)";
        private readonly AccessManagerBase _accessManager;

        public TripleEndpoint(AccessManagerBase accessManager)
        {
            this._accessManager = accessManager;
        }

        #region ITripleEndpoint

        public void CreateTriple(TripleModel triple)
        {
            var request = PrepareTripleRequest(CreateTriplePath, triple);
            _accessManager.Execute(request);
        }

        public void CreateTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple)
        {
            var request = PrepareTripleRequest(CreateTriplePath, triple);
            _accessManager.ExecuteAsync(request, success, failure);
        }

        public void DeleteTriple(TripleModel triple)
        {
            var request = PrepareTripleRequest(DeleteTriplePath, triple);
            _accessManager.Execute(request);
        }

        public void DeleteTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple)
        {
            var request = PrepareTripleRequest(DeleteTriplePath, triple);
            _accessManager.ExecuteAsync(request, success, failure);
        }

        #endregion

        private void Validate(TripleModel triple)
        {
            if (triple == null)
                throw new ArgumentNullException("triple");

            if (string.IsNullOrWhiteSpace(triple.Subject))
                throw new ArgumentException("Subject cannot be null.");
            else if (string.IsNullOrWhiteSpace(triple.Predicate))
                throw new ArgumentException("Predicate cannot be null.");
            else if (string.IsNullOrWhiteSpace(triple.Object))
                throw new ArgumentException("Object cannot be null.");
        }

        private IRestRequest PrepareTripleRequest(string path, TripleModel triple)
        {
            Validate(triple);

            var request = new RestRequest(Method.GET);
            request.Resource = path + "/?0={tripleSubject}&1={triplePredicate}&2={tripleObject}";

            request.AddParameter("tripleSubject", triple.Subject, ParameterType.UrlSegment);
            request.AddParameter("triplePredicate", triple.Predicate, ParameterType.UrlSegment);
            request.AddParameter("tripleObject", triple.Object, ParameterType.UrlSegment);

            return request;
        }
    }
}
