using RestSharp;
using RestSharp.Authenticators;
using SalesforceIQApi.Requests;

namespace SalesforceIQApi
{
    public class ApiRequest
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly IRestClient _client;

        public ListRequest ListRequest { get { return new ListRequest(_client); } }
        public ListItemRequest ListItemRequest { get { return new ListItemRequest(_client); } }
        public AccountRequest AccountRequest { get { return new AccountRequest(_client); } }
        public ContactRequest ContactRequest { get { return new ContactRequest(_client); } }
        public EventRequest EventRequest { get { return new EventRequest(_client); } }
        public UserRequest UserRequest { get { return new UserRequest(_client); } }

        public ApiRequest(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _client = new RestClient
            {
                BaseUrl = new System.Uri("https://api.salesforceiq.com/v2"),
                Authenticator = new HttpBasicAuthenticator(apiKey, apiSecret)
            };
        }
    }
}
