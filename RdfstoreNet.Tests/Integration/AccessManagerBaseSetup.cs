using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RdfstoreNet.Tests.Integration
{
    [TestClass]
    public abstract class AccessManagerBaseSetup
    {
        protected const string BaseUrl = "http://open-physiology.org:20060";

        public AccessManager AccessManager { get; set; }

        [TestInitialize]
        public void Init()
        {
            if (string.IsNullOrWhiteSpace(BaseUrl))
                throw new ArgumentException("In order to run integration tests, please define BaseUrl.");

            AccessManager = new AccessManager(BaseUrl);
        }
    }
}
