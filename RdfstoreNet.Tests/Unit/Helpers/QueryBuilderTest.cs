using Microsoft.VisualStudio.TestTools.UnitTesting;
using RdfstoreNet.Helpers;

namespace RdfstoreNet.Tests.Unit.Helpers
{
    [TestClass]
    public class QueryBuilderTest
    {
        [TestMethod]
        public void QueryBuilderUnitTest_Build_ReturnsEmptyQueryWithUrlEncode()
        {
            //assemble
            bool urlEncode = true;

            //act
            string query = QueryBuilder.Build(urlEncode);

            //assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(query));
        }

        [TestMethod]
        public void QueryBuilderUnitTest_Build_ReturnsEmptyQueryWithoutUrlEncode()
        {
            //assemble
            bool urlEncode = false;

            //act
            string query = QueryBuilder.Build(urlEncode);

            //assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(query));
        }

        [TestMethod]
        public void QueryBuilderUnitTest_Build_ReturnsQueryWithUrlEncode()
        {
            //assemble
            bool urlEncode = true;

            //act
            string query = QueryBuilder.Build(urlEncode, "param0", "http://purl.obolibrary.org/obo/FMA_13416");

            //assert
            Assert.AreEqual("0=param0&1=http%3a%2f%2fpurl.obolibrary.org%2fobo%2fFMA_13416", query);
        }

        [TestMethod]
        public void QueryBuilderUnitTest_Build_ReturnsQueryWithoutUrlEncode()
        {
            //assemble
            bool urlEncode = false;

            //act
            string query = QueryBuilder.Build(urlEncode, "param0", "http://purl.obolibrary.org/obo/FMA_13416");

            //assert
            Assert.AreEqual("0=param0&1=http://purl.obolibrary.org/obo/FMA_13416", query);
        }
    }
}
