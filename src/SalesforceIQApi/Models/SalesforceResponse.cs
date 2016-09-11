using System.Collections.Generic;

namespace SalesforceIQApi.Models
{
    public class SalesforcePagedResponse<T>
    {
        public SalesforcePagedResponse()
        {
            
        }

        public int Size { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public string QueryId { get; set; }

        public List<T> Objects { get; set; }
    }
}
