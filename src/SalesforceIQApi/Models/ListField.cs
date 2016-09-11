using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class ListField : ModelBase
    {
        public ListField()
        {
            ListOptions = new List<ListFieldOption>();
        }

        public string Name { get; set; }

        public bool IsMultiSelect { get; set; }

        public bool IsEditable { get; set; }

        public bool IsLinkedField { get; set; }

        public string DataType { get; set; }

        public List<ListFieldOption> ListOptions { get; set; }
    }
}
