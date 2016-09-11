using SalesforceIQApi.Models;
using SalesforceIQApi.Models.Enums;

namespace SalesforceIQApi.Interfaces
{
    public interface IContactRequest
    {
        /// <summary>
        /// Fetches a paged list of <see cref="Contact"/> objects. Responses are paginated, max of 200 at a time.
        /// </summary>
        /// <param name="ids">An optional, comma separated list of Contact identifiers.</param>
        /// <param name="start">An optional starting point for the returned page of records (defaults to 0). If you start at 50 you will retrieve records starting at the index 51 to your limit.</param>
        /// <param name="limit">An optional page size for the returned result (defaults to 50, max size is 200).</param>
        /// <param name="modifiedDate">Fetch all accounts modified at or after this timestamp (in milliseconds since epoch).</param>
        /// <returns>A paged response object containing all <see cref="Contact"/> objects</returns>
        SalesforcePagedResponse<Contact> GetAll(string[] ids = null, int start = 0, int limit = 50, int modifiedDate = 0);

        /// <summary>
        /// Fetches a specific <see cref="Contact"/> by ID. Contacts can only be queried by Contact ID.
        /// </summary>
        /// <param name="contactId">UUID of the <see cref="Contact"/>  to be fetched.</param>
        /// <returns>The requested <see cref="Contact"/></returns>
        Contact Get(string contactId);

        /// <summary>
        /// Creates a new Contact object and returns the created Contact with its new unique ID.
        /// </summary>
        /// <param name="contact">A <see cref="Contact"/>, without the Id or ModifiedDate fields (which will be generated on creation).</param>
        /// <returns>The created <see cref="Account"/> with its new unique ID</returns>
        Contact Create(Contact contact);

        /// <summary>
        /// Updates the details of a specific <see cref="Contact"/>. The Id and Name are required keys in the body.
        /// </summary>
        /// <param name="contact">The <see cref="Contact"/> object to update in SalesforceIQ</param>
        /// <returns>The updated <see cref="Contact"/> object</returns>
        Contact Update(Contact account);

        /// <summary>
        /// Creates or updates a <see cref="Contact"/> object
        /// </summary>
        /// <param name="contact">A <see cref="Contact"/> object which includes only the properties that need to be updated. This object should be included in the body of the request.</param>
        /// <returns>The upserted <see cref="Contact"/> </returns>
        Contact Upsert(Contact contact);

        /// <summary>
        /// Archives the specified <see cref="Contact"/>.
        /// </summary>
        /// <param name="contact">The <see cref="Contact"/>  to be archived.</param>
        /// <returns>A boolean that determines whether the archive completed successfully.</returns>
        bool Archive(Contact contact);
    }
}