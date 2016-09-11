using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesforceIQApi.Models;
using SalesforceIQApi.Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesforceIQApi.Test.Requests
{
    [TestClass]
    public class ContactRequestTests : BaseTest
    {
        [TestMethod]
        public void GetKnownTest()
        {
            var contact = ApiRequest.ContactRequest.Get(KnownContactId);

            Assert.IsNotNull(contact);
            Assert.AreEqual(KnownContactId, contact.Id);
        }

        [TestMethod]
        public void GetUnknownTest()
        {
            var contact = ApiRequest.ContactRequest.Get(UnknownId);

            Assert.IsNull(contact);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var contacts = ApiRequest.ContactRequest.GetAll();

            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Objects.Count() > 0);
        }

        [TestMethod, Ignore]
        public void CreateTest()
        {
            var newContact = new Contact();
            newContact.AddField("name", "Test Contact " + Guid.NewGuid().ToString());

            var contact = ApiRequest.ContactRequest.Create(newContact);

            Assert.IsNotNull(contact);
            Assert.IsTrue(!string.IsNullOrEmpty(contact.Id));

            bool deleted = ApiRequest.ContactRequest.Archive(contact);

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