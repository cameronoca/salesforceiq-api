using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace SalesforceIQApi.Test.Infrastructure
{
    [TestClass]
    public class BaseTest
    {
        protected string ApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiKey"];
            }
        }

        protected string ApiSecret
        {
            get
            {
                return ConfigurationManager.AppSettings["ApiSecret"];
            }
        }

        protected string KnownListId
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownListId"];
            }
        }

        protected string KnownAccountId
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownAccountId"];
            }
        }

        protected string KnownContactId
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownContactId"];
            }
        }

        protected string KnownContactEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownContactEmail"];
            }
        }

        protected string KnownListItemId
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownListItemId"];
            }
        }

        protected string KnownUserId
        {
            get
            {
                return ConfigurationManager.AppSettings["KnownUserId"];
            }
        }

        protected string UnknownId
        {
            get
            {
                return "000000000000000000000000";
            }
        }

        protected ApiRequest ApiRequest
        {
            get
            {
                return new ApiRequest(ApiKey, ApiSecret);
            }
        }
    }
}
