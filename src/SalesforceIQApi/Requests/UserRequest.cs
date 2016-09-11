using RestSharp;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;

namespace SalesforceIQApi.Requests
{
    public class UserRequest : RequestBase, IUserRequest
    {
        public UserRequest(IRestClient client) : base(client) { }

        public User Get(string userId)
        {
            return GetResponse<User>(string.Format("users/{0}", userId));
        }

    }
}
