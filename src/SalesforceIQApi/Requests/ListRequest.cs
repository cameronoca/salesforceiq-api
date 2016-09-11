using RestSharp;
using RestSharp.Extensions.MonoHttp;
using SalesforceIQApi.Extensions;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;
using System.Collections.Specialized;

namespace SalesforceIQApi.Requests
{
    public class ListRequest : RequestBase, IListRequest
    {
        public ListRequest(IRestClient client) : base(client) {}

        public SalesforcePagedResponse<List> GetAll(string[] ids = null, int start = 0, int limit = 50)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

            if (ids != null)
            {
                query["_ids"] = string.Join(",", ids);
            }
            query["_start"] = start.ToString();
            query["_limit"] = limit.ToString();

            return GetResponse<SalesforcePagedResponse<List>>(string.Format("lists{0}", query.ToQueryString()));
        }
        public List Get(string id)
        {
            return GetResponse<List>(string.Format("lists/{0}", id));
        }
    }
}
