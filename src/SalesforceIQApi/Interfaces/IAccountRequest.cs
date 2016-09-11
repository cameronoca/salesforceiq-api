using SalesforceIQApi.Models;

namespace SalesforceIQApi.Interfaces
{
    public interface IAccountRequest
    {
        /// <summary>
        /// Fetches a paged list of <see cref="Account"/> objects. Responses are paginated, max of 200 at a time.
        /// </summary>
        /// <param name="ids">An optional, comma separated list of Account identifiers.</param>
        /// <param name="start">An optional starting point for the returned page of records (defaults to 0). If you start at 50 you will retrieve records starting at the index 51 to your limit.</param>
        /// <param name="limit">An optional page size for the returned result (defaults to 50, max size is 200).</param>
        /// <param name="modifiedDate">Fetch all accounts modified at or after this timestamp (in milliseconds since epoch).</param>
        /// <returns>A paged response object containing all <see cref="Account"/> objects</returns>
        SalesforcePagedResponse<Account> GetAll(string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0);

        /// <summary>
        /// Fetches a specific <see cref="Account"/> by ID. Accounts can only be queried by Account ID.
        /// </summary>
        /// <param name="accountId">UUID of the Account to be fetched.</param>
        /// <returns>The requested <see cref="Account"/></returns>
        Account Get(string accountId);

        /// <summary>
        /// Creates a new <see cref="Account"/> object and returns the created Account with its new unique ID.
        ///
        /// The API will de-dupe any Accounts by name. In other words, if you attempt to create an Account name that already exists in your SalesforceIQ Instance, the request will update field values on the existing Account with any new data that you’re passing in your POST, but will not create a new Account.
        /// </summary>
        /// <param name="account">An <see cref="Account"/> object, without the Id or ModifiedDate fields (which will be generated on creation).</param>
        /// <returns>The created <see cref="Account"/> with its new unique ID</returns>
        Account Create(Account account);

        /// <summary>
        /// Updates the details of a specific <see cref="Account"/>. The Id and Name are required keys in the body.
        /// </summary>
        /// <param name="account">The <see cref="Account"/> object to update in SalesforceIQ</param>
        /// <returns>The updated <see cref="Account"/> object</returns>
        Account Update(Account account);

        /// <summary>
        /// Removes an <see cref="Account"/> from the Organization and returns true or false as to whether the deletion completed successfully.
        /// </summary>
        /// <param name="account">The <see cref="Account"/> to be deleted</param>
        /// <returns>True or false as to whether the deletion completed successfully.</returns>
        bool Delete(Account account);

        /// <summary>
        /// Fetches metadata information of the Account Property fields.
        /// </summary>
        /// <returns>Metadata information of the Account Property fields.</returns>
        AccountProperties GetAccountProperties();
    }
}