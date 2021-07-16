using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAllAsync();

        IEnumerable<Airport> GetFilteredAirports(string company, string airportName, string city, string country, int offset, int limit);

        int GetFilteredAirportsCount(string company, string airportName, string city, string country);

        Task PostAsync(Airport item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Airport item);
    }
}