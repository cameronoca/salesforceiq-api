using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Models;
using SalesforceIQApi.Test.Infrastructure;
using System.Linq;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass]
    public class AccountRequestTests : BaseTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            var pagedResponse = ApiRequest.AccountRequest.GetAll();

            Assert.IsNotNull(pagedResponse);
            Assert.IsTrue(pagedResponse.Objects.Count() > 0);
        }

        [TestMethod]
        public void GetKnownTest()
        {
            var account = ApiRequest.AccountRequest.Get(KnownAccountId);

            Assert.IsNotNull(account);
            Assert.AreEqual(KnownAccountId, account.Id);
        }

        [TestMethod]
        public void GetUnknownTest()
        {
            var account = ApiRequest.AccountRequest.Get(UnknownId);

            Assert.IsNull(account);
        }

        [TestMethod, Ignore]
        public void CreateTest()
        {
            var newAccount = new Account
            {
                Name = "Test Account (Soon to be deleted)"
            };

            var account = ApiRequest.AccountRequest.Create(newAccount);

            Assert.IsNotNull(account);
            Assert.IsTrue(!string.IsNullOrEmpty(account.Id));

            bool deleted = ApiRequest.AccountRequest.Delete(account);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetAccountPropertiesTest()
        {
            var accountFields = ApiRequest.AccountRequest.GetAccountProperties();

            Assert.IsNotNull(accountFields);
            Assert.IsNotNull(accountFields.Fields);
            Assert.IsTrue(accountFields.Fields.Count() > 0);
        }
    }
}
