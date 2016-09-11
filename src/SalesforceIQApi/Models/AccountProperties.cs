using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class AccountProperties
    {
        public AccountProperties()
        {
            Fields = new List<ListField>();
        }
        
        public List<ListField> Fields { get; set; }
    }
}
