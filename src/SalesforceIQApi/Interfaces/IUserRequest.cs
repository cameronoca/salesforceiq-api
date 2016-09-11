using SalesforceIQApi.Models;

namespace SalesforceIQApi.Interfaces
{
    public interface IUserRequest
    {
        User Get(string userId);
    }
}