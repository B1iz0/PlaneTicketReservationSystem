using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFilteredFlights(FlightFilter filter, int offset, int limit);

        int GetFilteredFlightsCount(FlightFilter filter);

        Task<Flight> GetByIdAsync(Guid id);

        Task PostAsync(Flight item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Flight item);

        IEnumerable<FlightHint> GetHints(FlightFilter flightFilter, int offset, int limit);
    }
}
