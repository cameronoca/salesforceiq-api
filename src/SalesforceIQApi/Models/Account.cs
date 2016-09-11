using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class Account : ModelBase
    {
        public Account()
        {
            FieldValues = new Dictionary<string, List<AccountField>>();
        }

        public long ModifiedDate { get; set; }

        public string Name { get; set; }

        public Dictionary<string, List<AccountField>> FieldValues { get; set; }

        public AccountField AddField(string key, string value)
        {
            if (!FieldValues.ContainsKey(key))
            {
                FieldValues.Add(key, new List<AccountField>());
            }

            var kvp = FieldValues[key];

            var newAccountField = new AccountField
            {
                Raw = value
            };

            kvp.Add(newAccountField);

            return newAccountField;
        }
    }
}
