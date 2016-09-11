using Newtonsoft.Json;
using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class Event : ModelBase
    {
        public Event()
        {
            Participants = new List<EventParticipant>();
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        [JsonProperty(PropertyName = "participantIds")]
        public List<EventParticipant> Participants { get; set; }

        public EventParticipant AddParticipant(string type, string value)
        {
            var participant = new EventParticipant(type, value);

            Participants.Add(participant);

            return participant;
        }
    }
}
