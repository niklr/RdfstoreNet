using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RdfstoreNet.Endpoints.Interfaces;
using RdfstoreNet.Endpoints;
using RdfstoreNet.Models.Template;

namespace RdfstoreNet.Tests.Integration.Endpoints
{
    [TestClass]
    public class TemplateEndpointIntegrationTest : AccessManagerBaseSetup
    {
        private ITemplateEndpoint TemplateEndpoint { get; set; }

        [TestInitialize]
        public new void Init()
        {
            base.Init();
            TemplateEndpoint = new TemplateEndpoint(AccessManager);
        }

        [TestMethod]
        public void TemplateEndpointIntegrationTest_CallTemplate_Get_Resources()
        {
            //assemble
            string templateName = "Get_Resources";

            //act
            TemplateResponseModel response = TemplateEndpoint.CallTemplate(templateName);

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Results.Count > 0);
            Assert.AreEqual(1, response.Results[0].Length);
        }

        [TestMethod]
        public void TemplateEndpointIntegrationTest_CallTemplate_Raw_SPARQL()
        {
            //assemble
            string templateName = "Raw_SPARQL";

            //act
            TemplateResponseModel response = TemplateEndpoint.CallTemplate(templateName, "SELECT DISTINCT * WHERE { ?s ?p ?o } LIMIT 20");

            //assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Results.Count > 0);
            Assert.IsTrue(response.Results.Count <= 20);
            Assert.AreEqual(3, response.Results[0].Length);
        }

        [TestMethod]
        public void TemplateEndpointIntegrationTest_CallTemplate_Insert_Triple_TemplateEntryMissing()
        {
            //assemble
            string templateName = "Insert_Triple_(Fuseki)";

            //act
            TemplateResponseModel response = TemplateEndpoint.CallTemplate(templateName, "a", "b");

            //assert
            Assert.IsNotNull(response);
            Assert.AreEqual("Error: Template entry 'Object' is missing", response.Content);
            Assert.AreEqual(0, response.Results.Count);
        }
    }
}
