using RestSharp;
using SalesforceIQApi.Extensions;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;
using SalesforceIQApi.Models.Enums;
using System;
using System.Collections.Specialized;

namespace SalesforceIQApi.Requests
{
    public class ListItemRequest : RequestBase, IListItemRequest
    {
        public ListItemRequest(IRestClient client) : base(client) {}

        public ListItem Get(string listId, string listItemId)
        {
            return GetResponse<ListItem>(string.Format("lists/{0}/listitems/{1}", listId, listItemId));
        }

        public SalesforcePagedResponse<ListItem> GetAll(string listId, string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0, string[] contactIds = null, string[] accountIds = null)
        {
            var query = new NameValueCollection();

            if(ids != null)
            {
                query["_ids"] = string.Join(",", ids);
            }
            if(contactIds != null)
            {
                query["contactIds"] = string.Join(",", contactIds);
            }
            if(accountIds != null)
            {
                query["accountIds"] = string.Join(",", accountIds);
            }
            if (modifiedDate != 0)
            {
                query["modifiedDate"] = modifiedDate.ToString();
            }

            query["_start"] = start.ToString();
            query["_limit"] = limit.ToString();

            return GetResponse<SalesforcePagedResponse<ListItem>>(string.Format("lists/{0}/listitems{1}", listId, query.ToQueryString()));
        }

        public ListItem Create(ListItem listItem)
        {
            return PostResponse(string.Format("lists/{0}/listitems", listItem.ListId), listItem);
        }

        //TODO: Implement ListItemRequest.Update
        public ListItem Update(ListItem account)
        {
            throw new NotImplementedException();
        }

        //TODO: Implement ListItemRequest.Upsert
        public ListItem Upsert(ListItem listItem, UpsertFields upsertField )
        {
            throw new NotImplementedException();
        }

        public bool Delete(ListItem listItem)
        {
            return DeleteResponse<bool>(string.Format("lists/{0}/listitems/{1}", listItem.ListId, listItem.Id));
        }
    }
}
