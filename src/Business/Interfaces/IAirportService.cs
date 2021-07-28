using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAllAsync();

        IEnumerable<Airport> GetFilteredAirports(AirportFilter filter, int offset, int limit);

        int GetFilteredAirportsCount(AirportFilter filter);

        Task PostAsync(Airport item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Airport item);

        IEnumerable<AirportHint> GetHints(AirportFilter filter, int offset, int limit);
    }
}