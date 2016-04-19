using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RdfstoreNet.Endpoints;
using RdfstoreNet.Models.Triple;

namespace RdfstoreNet.Tests.Unit.Endpoints
{
    [TestClass]
    public class TripleEndpointUnitTest
    {
        #region CreateTriple

        [TestMethod]
        public void TripleEndpointUnitTest_CreateTriple_Success()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel
            {
                Subject = "a",
                Predicate = "b",
                Object = "c"
            };

            //act
            tripleEndpoint.CreateTriple(triple);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TripleEndpointUnitTest_CreateTriple_ArgumentNullException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);

            //act
            tripleEndpoint.CreateTriple(null);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TripleEndpointUnitTest_CreateTriple_ArgumentException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel();

            //act
            tripleEndpoint.CreateTriple(triple);

            //assert
        }

        #endregion

        #region CreateTripleAsync

        [TestMethod]
        public void TripleEndpointUnitTest_CreateTripleAsync_Success()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel
            {
                Subject = "a",
                Predicate = "b",
                Object = "c"
            };

            //act
            tripleEndpoint.CreateTripleAsync(() => { }, (ex) => { }, triple);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TripleEndpointUnitTest_CreateTripleAsync_ArgumentNullException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);

            //act
            tripleEndpoint.CreateTripleAsync(() => { }, (ex) => { }, null);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TripleEndpointUnitTest_CreateTripleAsync_ArgumentException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel();

            //act
            tripleEndpoint.CreateTripleAsync(() => { }, (ex) => { }, triple);

            //assert
        }

        #endregion

        #region DeleteTriple

        [TestMethod]
        public void TripleEndpointUnitTest_DeleteTriple_Success()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel
            {
                Subject = "a",
                Predicate = "b",
                Object = "c"
            };

            //act
            tripleEndpoint.DeleteTriple(triple);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TripleEndpointUnitTest_DeleteTriple_ArgumentNullException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);

            //act
            tripleEndpoint.DeleteTriple(null);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TripleEndpointUnitTest_DeleteTriple_ArgumentException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel();

            //act
            tripleEndpoint.DeleteTriple(triple);

            //assert
        }

        #endregion

        #region DeleteTripleAsync

        [TestMethod]
        public void TripleEndpointUnitTest_DeleteTripleAsync_Success()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel
            {
                Subject = "a",
                Predicate = "b",
                Object = "c"
            };

            //act
            tripleEndpoint.DeleteTripleAsync(() => { }, (ex) => { }, triple);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TripleEndpointUnitTest_DeleteTripleAsync_ArgumentNullException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);

            //act
            tripleEndpoint.DeleteTripleAsync(() => { }, (ex) => { }, null);

            //assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TripleEndpointUnitTest_DeleteTripleAsync_ArgumentException()
        {
            //assemble
            Mock<AccessManagerBaseMock> accessManager = new Mock<AccessManagerBaseMock>(string.Empty);
            TripleEndpoint tripleEndpoint = new TripleEndpoint(accessManager.Object);
            TripleModel triple = new TripleModel();

            //act
            tripleEndpoint.DeleteTripleAsync(() => { }, (ex) => { }, triple);

            //assert
        }

        #endregion
    }
}
