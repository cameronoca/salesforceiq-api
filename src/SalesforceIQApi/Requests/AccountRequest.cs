using RestSharp;
using SalesforceIQApi.Extensions;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;
using System;
using System.Collections.Specialized;

namespace SalesforceIQApi.Requests
{
    public class AccountRequest : RequestBase, IAccountRequest
    {
        public AccountRequest(IRestClient client) : base(client) { }

        public SalesforcePagedResponse<Account> GetAll(string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0)
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

            return GetResponse<SalesforcePagedResponse<Account>>(string.Format("accounts{0}", query.ToQueryString()));
        }

        public Account Get(string accountId)
        {
            return GetResponse<Account>(string.Format("accounts/{0}", accountId));
        }

        public Account Create(Account account)
        {
            return PostResponse<Account>("accounts", account);
        }

        //TODO: Implement AccountRequest.Update
        public Account Update(Account account)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Account account)
        {
            return DeleteResponse<bool>(string.Format("accounts/{0}", account.Id));
        }

        public AccountProperties GetAccountProperties()
        {
            return GetResponse<AccountProperties>("accounts/fields");
        }
    }
}
