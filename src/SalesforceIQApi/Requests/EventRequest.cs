using RestSharp;
using SalesforceIQApi.Interfaces;
using SalesforceIQApi.Models;

namespace SalesforceIQApi.Requests
{
    public class EventRequest : RequestBase, IEventRequest
    {
        public EventRequest(IRestClient client) : base(client) { }

        public void Create(Event newEvent)
        {
            var endpoint = "events";
            var response = PutResponse(endpoint, newEvent);
        }
    }
}
