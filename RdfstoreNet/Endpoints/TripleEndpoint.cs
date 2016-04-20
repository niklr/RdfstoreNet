using System;
using RdfstoreNet.Endpoints.Interfaces;
using RdfstoreNet.Models.Triple;

namespace RdfstoreNet.Endpoints
{
    public class TripleEndpoint : ITripleEndpoint
    {
        private const string CreateTriplePath = "Insert_Triple_(Fuseki)";
        private const string DeleteTriplePath = "Delete_Triple_(Fuseki)";
        private readonly AccessManagerBase _accessManager;
        private readonly ITemplateEndpoint _templateEndpoint;

        public TripleEndpoint(AccessManagerBase accessManager)
        {
            _accessManager = accessManager;
            _templateEndpoint = new TemplateEndpoint(accessManager);
        }

        #region ITripleEndpoint

        public void CreateTriple(TripleModel triple)
        {
            Validate(triple);
            _templateEndpoint.CallTemplate(CreateTriplePath, triple.Subject, triple.Predicate, triple.Object);
        }

        public void CreateTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple)
        {
            Validate(triple);
            _templateEndpoint.CallTemplateAsync(CreateTriplePath, success, failure, triple.Subject, triple.Predicate, triple.Object);
        }

        public void DeleteTriple(TripleModel triple)
        {
            Validate(triple);
            _templateEndpoint.CallTemplate(DeleteTriplePath, triple.Subject, triple.Predicate, triple.Object);
        }

        public void DeleteTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple)
        {
            Validate(triple);
            _templateEndpoint.CallTemplateAsync(DeleteTriplePath, success, failure, triple.Subject, triple.Predicate, triple.Object);
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
    }
}
