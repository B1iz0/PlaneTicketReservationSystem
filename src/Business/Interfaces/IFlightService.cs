using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFilteredFlights(int offset, int limit, string departureCity, string arrivalCity);

        int GetFilteredFlightsCount(string departureCity, string arrivalCity);

        Task<Flight> GetByIdAsync(Guid id);

        Task PostAsync(Flight item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Flight item);
    }
}
