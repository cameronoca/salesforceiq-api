using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Test.Infrastructure;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass()]
    public class UserRequestTests : BaseTest
    {
        [TestMethod()]
        public void GetKnownTest()
        {
            var user = ApiRequest.UserRequest.Get(KnownUserId);

            Assert.IsNotNull(user);
            Assert.AreEqual(KnownUserId, user.Id);
        }

        [TestMethod]
        public void GetUnknownTest()
        {
            var user = ApiRequest.UserRequest.Get(UnknownId);

            Assert.IsNull(user);
        }
    }
}