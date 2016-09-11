using Newtonsoft.Json;

namespace SalesforceIQApi.Models
{
    public class ContactPropertyMetadata
    {
        public ContactPropertyMetadata()
        {

        }

        [JsonProperty(PropertyName = "stype")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "raw_val")]
        public string Value { get; set; }

        public bool Primary { get; set; }

        [JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "job_title")]
        public string JobTitle { get; set; }
    }
}