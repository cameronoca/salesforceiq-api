using SalesforceIQApi.Models;

namespace SalesforceIQApi.Interfaces
{
    public interface IEventRequest
    {
        /// <summary>
        /// Creates the specified <see cref="Event"/>.
        /// </summary>
        /// <param name="newEvent">The <see cref="Event"/> .</param>
        void Create(Event newEvent);
    }
}