using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Test.Infrastructure;
using System.Linq;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass]
    public class ListRequestTests : BaseTest
    {
        [TestMethod]
        public void GetAllWithNoInputArgumentTest()
        {
            var pagedResponse = ApiRequest.ListRequest.GetAll();

            Assert.IsNotNull(pagedResponse);
            Assert.IsTrue(pagedResponse.Objects.Count() > 0);
        }

        [TestMethod]
        public void GetAllWithSpecificIdentifiersTest()
        {
            var pagedResponse = ApiRequest.ListRequest.GetAll(new string[] { KnownListId });

            Assert.IsNotNull(pagedResponse);
            Assert.AreEqual(1, pagedResponse.Objects.Count());
        }

        [TestMethod]
        public void GetAllWithPagingEnabledTest()
        {
            var pagedResponse = ApiRequest.ListRequest.GetAll(start: 0, limit: 2);

            Assert.IsNotNull(pagedResponse);
            Assert.AreEqual(2, pagedResponse.Objects.Count());
        }

        [TestMethod]
        public void GetKnownTest()
        {
            var list = ApiRequest.ListRequest.Get(KnownListId);

            Assert.IsNotNull(list);
            Assert.AreEqual(KnownListId, list.Id);
        }

        [TestMethod]
        public void GetUnknownTest()
        {
            var list = ApiRequest.ListRequest.Get(UnknownId);

            Assert.IsNull(list);
        }
    }
}
