using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class List : ModelBase
    {
        public List()
        {
            Fields = new List<ListField>();
        }

        public string Title { get; set; }

        public string ListType { get; set; }

        public long ModifiedDate{ get; set; }

        public List<ListField> Fields { get; set; }
    }
}
