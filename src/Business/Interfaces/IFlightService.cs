using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFilteredFlights(int offset, int limit, string departureCity, string arrivalCity);

        int GetFilteredFlightsCount(string departureCity, string arrivalCity);

        Task<Flight> GetByIdAsync(int id);

        Task PostAsync(Flight item);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, Flight item);
    }
}
