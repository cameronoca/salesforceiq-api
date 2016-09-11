using System;

namespace SalesforceIQApi.Exceptions
{
    public class SalesforceException : Exception
    {
        public SalesforceException(string message) : base(message)
        {
        }
    }
}
