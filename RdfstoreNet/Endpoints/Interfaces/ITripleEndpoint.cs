using RdfstoreNet.Models.Triple;
using System;

namespace RdfstoreNet.Endpoints.Interfaces
{
    interface ITripleEndpoint
    {
        // Create Triple
        void CreateTriple(TripleModel triple);
        void CreateTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple);
        // Delete Triple
        void DeleteTriple(TripleModel triple);
        void DeleteTripleAsync(Action success, Action<RdfstoreException> failure, TripleModel triple);
    }
}
