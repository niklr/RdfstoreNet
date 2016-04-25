using Microsoft.VisualStudio.TestTools.UnitTesting;
using RdfstoreNet.Endpoints.Interfaces;
using RdfstoreNet.Endpoints;
using RdfstoreNet.Models.Triple;
using System.Threading;

namespace RdfstoreNet.Tests.Integration.Endpoints
{
    [TestClass]
    public class TripleEndpointIntegrationTest : AccessManagerBaseSetup
    {
        private ITripleEndpoint TripleEndpoint { get; set; }

        [TestInitialize]
        public new void Init()
        {
            base.Init();
            TripleEndpoint = new TripleEndpoint(AccessManager);
        }

        [TestMethod]
        public void TripleEndpointIntegrationTest_CreateTriple()
        {
            //assemble
            TripleModel triple = new TripleModel()
            {
                Subject = "https://github.com/niklr/RdfstoreNet/subjects/a",
                Predicate = "https://github.com/niklr/RdfstoreNet/predicates/b",
                Object = "https://github.com/niklr/RdfstoreNet/objects/c"
            };

            //act
            TripleEndpoint.CreateTriple(triple);

            //assert
        }

        [TestMethod]
        public void TripleEndpointIntegrationTest_CreateTripleAsync()
        {
            //assemble
            string message = string.Empty;
            ManualResetEvent completion = new ManualResetEvent(false);
            TripleModel triple = new TripleModel()
            {
                Subject = "https://github.com/niklr/RdfstoreNet/subjects/a",
                Predicate = "https://github.com/niklr/RdfstoreNet/predicates/b",
                Object = "https://github.com/niklr/RdfstoreNet/objects/c"
            };

            //act
            TripleEndpoint.CreateTripleAsync(() => { message = "completed"; completion.Set(); }, 
                (ex) => { message = ex.Message; completion.Set(); }, triple);
            completion.WaitOne();

            //assert
            Assert.AreEqual("completed", message);
        }

        [TestMethod]
        public void TripleEndpointIntegrationTest_DeleteTriple()
        {
            //assemble
            TripleModel triple = new TripleModel()
            {
                Subject = "https://github.com/niklr/RdfstoreNet/subjects/a",
                Predicate = "https://github.com/niklr/RdfstoreNet/predicates/b",
                Object = "https://github.com/niklr/RdfstoreNet/objects/c"
            };

            //act
            TripleEndpoint.DeleteTriple(triple);

            //assert
        }

        [TestMethod]
        public void TripleEndpointIntegrationTest_DeleteTripleAsync()
        {
            //assemble
            string message = string.Empty;
            ManualResetEvent completion = new ManualResetEvent(false);
            TripleModel triple = new TripleModel()
            {
                Subject = "https://github.com/niklr/RdfstoreNet/subjects/a",
                Predicate = "https://github.com/niklr/RdfstoreNet/predicates/b",
                Object = "https://github.com/niklr/RdfstoreNet/objects/c"
            };

            //act
            TripleEndpoint.DeleteTripleAsync(() => { message = "completed"; completion.Set(); },
                (ex) => { message = ex.Message; completion.Set(); }, triple);
            completion.WaitOne();

            //assert
            Assert.AreEqual("completed", message);
        }
    }
}
