namespace SalesforceIQApi.Models
{
    public class ContactProperty
    {
        public ContactProperty()
        {
            Metadata = new ContactPropertyMetadata();
        }

        public string Value { get; set; }

        public ContactPropertyMetadata Metadata { get; set; }
    }
}
