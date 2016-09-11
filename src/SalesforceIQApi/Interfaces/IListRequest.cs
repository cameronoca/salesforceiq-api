using SalesforceIQApi.Models;

namespace SalesforceIQApi.Interfaces
{
    public interface IListRequest
    {
        /// <summary>
        /// Fetches a paged list of <see cref="List"/> objects. Responses are paginated, max of 200 at a time.
        /// </summary>
        /// <param name="ids">An optional, comma separated list of List identifiers.</param>
        /// <param name="start">An optional starting point for the returned page of records (defaults to 0). If you start at 50 you will retrieve records starting at the index 51 to your limit.</param>
        /// <param name="limit">An optional page size for the returned result (defaults to 50, max size is 200).</param>
        /// <returns>A paged response object containing all <see cref="List"/> objects</returns>
        SalesforcePagedResponse<List> GetAll(string[] ids = null, int start = 0, int limit = 50);

        /// <summary>
        /// Fetches a specific <see cref="List"/> by ID. 
        /// </summary>
        /// <param name="listId">UUID of the List to be fetched.</param>
        /// <returns>The requested <see cref="List"/></returns>
        List Get(string id);
    }
}
