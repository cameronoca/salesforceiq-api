using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Models;
using SalesforceIQApi.Test.Infrastructure;
using System.Collections.ObjectModel;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass()]
    public class EventRequestTests : BaseTest
    {
        [TestMethod(), Ignore]
        public void CreateTest()
        {
            var newEvent = new Event
            {
                Subject = "Test Event",
                Body = "This is a test event, please disregard"
            };
            newEvent.AddParticipant("email", KnownContactEmail);

            ApiRequest.EventRequest.Create(newEvent);

            Assert.IsTrue(true);
        }
    }
}