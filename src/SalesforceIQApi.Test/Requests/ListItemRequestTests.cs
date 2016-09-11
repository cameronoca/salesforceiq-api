using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Models;
using SalesforceIQApi.Test.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass]
    public class ListItemRequestTests : BaseTest
    {
        [TestMethod]
        public void GetKnownTest()
        {
            var listItem = ApiRequest.ListItemRequest.Get(KnownListId, KnownListItemId);

            Assert.IsNotNull(listItem);
            Assert.AreEqual(KnownListItemId, listItem.Id);
        }

        [TestMethod]
        public void GetUnknownTest()
        {
            var listItem = ApiRequest.ListItemRequest.Get(KnownListId, UnknownId);

            Assert.IsNull(listItem);
        }

        [TestMethod]
        public void GetAllWithNoInputArgumentsTest()
        {
            var pagedResponse = ApiRequest.ListItemRequest.GetAll(KnownListId);

            Assert.IsNotNull(pagedResponse);
            Assert.IsTrue(pagedResponse.Objects.Count() > 0);
        }

        [TestMethod]
        public void GetAllWithSpecificIdentifiersTest()
        {
            var pagedResponse = ApiRequest.ListItemRequest.GetAll(KnownListId, new string[] { KnownListItemId });

            Assert.IsNotNull(pagedResponse);
            Assert.AreEqual(1, pagedResponse.Objects.Count());
        }

        [TestMethod]
        public void GetAllWithPagingEnabledTest()
        {
            var pagedResponse = ApiRequest.ListItemRequest.GetAll(KnownListId, start: 0, limit: 2);

            Assert.IsNotNull(pagedResponse);
            Assert.AreEqual(2, pagedResponse.Objects.Count());
        }

        [TestMethod, Ignore]
        public void CreateTest()
        {
            var newListItem = new ListItem
            {
                ContactIds = new List<string>
                {
                    KnownContactId
                },
                ListId = KnownListId
            };

            var listItem = ApiRequest.ListItemRequest.Create(newListItem);

            Assert.IsNotNull(listItem);
            Assert.IsNotNull(listItem.Id);

            var deleted = ApiRequest.ListItemRequest.Delete(listItem);

            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void UpsertTest()
        {
            Assert.Inconclusive();
        }
    }
}