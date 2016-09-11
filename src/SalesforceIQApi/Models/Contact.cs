using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class Contact : ModelBase
    {
        public Contact()
        {
            Properties = new Dictionary<string, List<ContactProperty>>();
        }

        public long ModifiedDate { get; set; }

        public Dictionary<string, List<ContactProperty>> Properties { get; set; }

        public ContactProperty AddField(string key, string value)
        {
            if (!Properties.ContainsKey(key))
            {
                Properties.Add(key, new List<ContactProperty>());
            }

            var kvp = Properties[key];

            var newContactProperty = new ContactProperty
            {
                Value = value
            };

            kvp.Add(newContactProperty);

            return newContactProperty;
        }
    }
}
