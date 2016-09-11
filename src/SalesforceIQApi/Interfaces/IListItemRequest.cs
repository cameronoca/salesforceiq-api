using SalesforceIQApi.Models;
using SalesforceIQApi.Models.Enums;

namespace SalesforceIQApi.Interfaces
{
    public interface IListItemRequest
    {
        /// <summary>
        /// Fetches a paged list of <see cref="ListItem"/> objects. Responses are paginated, max of 200 at a time.
        /// </summary>
        /// <param name="listId">The list identifier.</param>
        /// <param name="ids">An optional, comma separated list of ListItem identifiers.</param>
        /// <param name="start">An optional starting point for the returned page of records (defaults to 0). If you start at 50 you will retrieve records starting at the index 51 to your limit.</param>
        /// <param name="limit">An optional page size for the returned result (defaults to 50, max size is 200).</param>
        /// <param name="modifiedDate">Fetch all listItems modified at or after this timestamp (in milliseconds since epoch).</param>
        /// <param name="contactIds">An optional, comma separated list of contact identifiers.</param>
        /// <param name="listItemIds">An optional, comma separated list of contact identifiers.</param>
        /// <returns>A paged response object containing all <see cref="ListItem"/> objects</returns>
        SalesforcePagedResponse<ListItem> GetAll(string listId, string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0, string[] contactIds = null, string[] listItemIds = null);

        /// <summary>
        /// Fetches a specific <see cref="ListItem"/> by ID. ListItems can only be queried by ListItem ID.
        /// </summary>
        /// <param name="listItemId">UUID of the ListItem to be fetched.</param>
        /// <returns>The requested <see cref="ListItem"/></returns>
        ListItem Get(string listId, string listItemId);

        /// <summary>
        /// Creates a new <see cref="ListItem"/>  object and returns the created object with it’s new ID.
        /// </summary>
        /// <param name="listItem">A <see cref="ListItem"/> , without the id, modifiedDate, or createdDate fields (which will be generated on creation).</param>
        /// <returns>The created <see cref="ListItem"/> with its new unique ID</returns>
        ListItem Create(ListItem listItem);

        /// <summary>
        /// Updates the details of a specific <see cref="ListItem"/>. The Id and Name are required keys in the body.
        /// </summary>
        /// <param name="listItem">The <see cref="ListItem"/> object to update in SalesforceIQ</param>
        /// <returns>The updated <see cref="ListItem"/> object</returns>
        ListItem Update(ListItem listItem);

        /// <summary>
        /// Removes an <see cref="ListItem"/> from the Organization and returns true or false as to whether the deletion completed successfully.
        /// </summary>
        /// <param name="listItem">The <see cref="ListItem"/> to be deleted</param>
        /// <returns>True or false as to whether the deletion completed successfully.</returns>
        bool Delete(ListItem listItem);

        /// <summary>
        /// Creates or updates a <see cref="ListItem"/> object
        /// </summary>
        /// <param name="listItem">A <see cref="ListItem"/> object which includes only the properties that need to be updated. This object should be included in the body of the request.</param>
        /// <returns>The upserted <see cref="ListItem"/> </returns>
        ListItem Upsert(ListItem listItem, UpsertFields upsertField);
    }
}