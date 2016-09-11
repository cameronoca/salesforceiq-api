using RestSharp;
using RestSharp.Serializers;
using SalesforceIQApi.Exceptions;
using System.Net;

namespace SalesforceIQApi.Requests
{
    public class RequestBase
    {
        protected readonly IRestClient _client;

        public RequestBase()
        {

        }
        public RequestBase(IRestClient client)
        {
            _client = client;
        }


        protected RestRequest BuildGetRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET) { RequestFormat = DataFormat.Json };

            request.JsonSerializer = new JsonNetSerializer();

            return request;
        }
        protected RestRequest BuildPostRequest(string endpoint, object entity)
        {
            var request = new RestRequest(endpoint, Method.POST) { RequestFormat = DataFormat.Json };

            request.JsonSerializer = new JsonNetSerializer();

            request.AddBody(entity);

            return request;
        }
        protected RestRequest BuildDeleteRequest(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.DELETE) { RequestFormat = DataFormat.Json };

            request.JsonSerializer = new JsonNetSerializer();

            return request;
        }
        protected RestRequest BuildPutRequest(string endpoint, object entity)
        {
            var request = new RestRequest(endpoint, Method.PUT) { RequestFormat = DataFormat.Json };

            request.JsonSerializer = new JsonNetSerializer();

            request.AddBody(entity);

            return request;
        }

  
        protected T GetResponse<T>(string endpoint) where T : new()
        {
            var request = BuildGetRequest(endpoint);

            var response = buildResponse<T>(request);

            return response;
        }

        protected T PostResponse<T>(string endpoint, T obj) where T : new()
        {
            var request = BuildPostRequest(endpoint, obj);

            return buildResponse<T>(request);
        }

        protected T PutResponse<T>(string endpoint, T obj) where T : new()
        {
            var request = BuildPutRequest(endpoint, obj);

            return buildResponse<T>(request);
        }

        protected T DeleteResponse<T>(string endpoint) where T : new()
        {
            var request = BuildDeleteRequest(endpoint);

            return buildResponse<T>(request);
        }

        private T buildResponse<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                    return response.Data;
                case HttpStatusCode.MultipleChoices:
                    throw new SalesforceException("300 - Ambigious");
                case HttpStatusCode.Moved:
                    throw new SalesforceException("301 - Moved / Moved Permanently");
                case HttpStatusCode.Redirect:
                    throw new SalesforceException("302 - Redirect / Found");
                case HttpStatusCode.SeeOther:
                    throw new SalesforceException("303 - See Other / Redirect");
                case HttpStatusCode.NotModified:
                    throw new SalesforceException("304 - Not Mofidied");
                case HttpStatusCode.UseProxy:
                    throw new SalesforceException("305 - Use Proxy");
                case HttpStatusCode.Unused:
                    throw new SalesforceException("306 - Unused");
                case HttpStatusCode.TemporaryRedirect:
                    throw new SalesforceException("307 - Temporary Redirect / Redirect keep verb");
                case HttpStatusCode.BadRequest:
                    throw new SalesforceException("400 - Bad request (check that all fields have been entered");
                case HttpStatusCode.Unauthorized:
                    throw new SalesforceException("401 - Unauthorized");
                case HttpStatusCode.PaymentRequired:
                    throw new SalesforceException("402 - Payment Required");
                case HttpStatusCode.Forbidden:
                    throw new SalesforceException("403 - Forbidden");
                case HttpStatusCode.NotFound:
                    return default(T);
                case HttpStatusCode.MethodNotAllowed:
                    throw new SalesforceException("405 - Method Not Allowed");
                case HttpStatusCode.NotAcceptable:
                    throw new SalesforceException("406 - Not Acceptable");
                case HttpStatusCode.ProxyAuthenticationRequired:
                    throw new SalesforceException("407 - Proxy Authentication Required");
                case HttpStatusCode.RequestTimeout:
                    throw new SalesforceException("408 - Request Timeout");
                case HttpStatusCode.Conflict:
                    throw new SalesforceException("409 - Conflict (Did you already post that resource?)");
                case HttpStatusCode.Gone:
                    throw new SalesforceException("410 - Gone");
                case HttpStatusCode.LengthRequired:
                    throw new SalesforceException("411 - Length Required");
                case HttpStatusCode.PreconditionFailed:
                    throw new SalesforceException("412 - Precondition Failed");
                case HttpStatusCode.RequestEntityTooLarge:
                    throw new SalesforceException("413 - Request Entity Too Large");
                case HttpStatusCode.RequestUriTooLong:
                    throw new SalesforceException("414 - Request URI Too Long");
                case HttpStatusCode.UnsupportedMediaType:
                    throw new SalesforceException("415 - Unsupported Media Type");
                case HttpStatusCode.RequestedRangeNotSatisfiable:
                    throw new SalesforceException("416 - Requested Range Not Satisfiable");
                case HttpStatusCode.ExpectationFailed:
                    throw new SalesforceException("417 - Expectation Failed");
                case HttpStatusCode.UpgradeRequired:
                    throw new SalesforceException("426 - Upgrade Required");
                case HttpStatusCode.InternalServerError:
                    throw new SalesforceException("500 - Internal Server Error (Something went wrong with Salesforce IQ API)");
                case HttpStatusCode.NotImplemented:
                    throw new SalesforceException("501 - Not Implemented");
                case HttpStatusCode.BadGateway:
                    throw new SalesforceException("502 - Bad Gateway");
                case HttpStatusCode.ServiceUnavailable:
                    throw new SalesforceException("503 - Service Unavailable");
                case HttpStatusCode.GatewayTimeout:
                    throw new SalesforceException("504 - Gateway Timeout");
                case HttpStatusCode.HttpVersionNotSupported:
                    throw new SalesforceException("505 - HTTP Version Not Supported");
                default:
                    throw new SalesforceException("Unknown Error");
            }
        }
    }
}
