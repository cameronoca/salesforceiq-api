using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class ListItem : ModelBase
    {
        public ListItem()
        {
            FieldValues = new Dictionary<string, List<ListItemField>>();
        }

        public long ModifiedDate { get; set; }

        public long CreatedDate { get; set; }

        public string ListId { get; set; }

        public string AccountId { get; set; }

        public List<string> ContactIds { get; set; }

        public string Name { get; set; }

        public Dictionary<string, List<ListItemField>> FieldValues { get; set; }

        public ListItemField AddField(string key, string value)
        {
            if (!FieldValues.ContainsKey(key))
            {
                FieldValues.Add(key, new List<ListItemField>());
            }

            var kvp = FieldValues[key];

            var newListItemField = new ListItemField
            {
                Raw = value
            };

            kvp.Add(newListItemField);

            return newListItemField;
        }
    }
}
