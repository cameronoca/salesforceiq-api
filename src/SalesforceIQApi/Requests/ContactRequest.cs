using RestSharp;
using SalesforceIQApi.Extensions;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;
using SalesforceIQApi.Models.Enums;
using System;
using System.Collections.Specialized;

namespace SalesforceIQApi.Requests
{
    public class ContactRequest : RequestBase, IContactRequest
    {
        public ContactRequest(IRestClient client) : base(client) { }

        public Contact Get(string contactId)
        {
            return GetResponse<Contact>(string.Format("contacts/{0}", contactId));
        }

        public SalesforcePagedResponse<Contact> GetAll(string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0)
        {
            var query = new NameValueCollection();

            if (ids != null)
            {
                query["_ids"] = string.Join(",", ids);
            }
            if (modifiedDate != 0)
            {
                query["modifiedDate"] = modifiedDate.ToString();
            }

            query["_start"] = start.ToString();
            query["_limit"] = limit.ToString();

            return GetResponse<SalesforcePagedResponse<Contact>>(string.Format("contacts{0}", query.ToQueryString()));
        }

        public Contact Create(Contact contact)
        {
            return PostResponse("contacts", contact);
        }

        //TODO: Implement ContactRequest.Update
        public Contact Update(Contact account)
        {
            throw new NotImplementedException();
        }

        //TODO: Implement ContactRequest.Update
        public Contact Upsert(Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool Archive(Contact contact)
        {
            return DeleteResponse<bool>(string.Format("contacts/{0}", contact.Id));
        }
    }
}
