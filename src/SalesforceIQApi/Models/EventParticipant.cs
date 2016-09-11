namespace SalesforceIQApi.Models
{
    public class EventParticipant 
    {
        public EventParticipant()
        {

        }

        public EventParticipant(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; }
        
        public string Value { get; set; }
    }
}
