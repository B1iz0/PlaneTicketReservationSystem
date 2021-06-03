using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IFlightService : IDataService<Flight>
    {
        IEnumerable<Flight> GetFilteredFlights(int offset, int limit, string departureCity, string arrivalCity);

        int GetFilteredFlightsCount(string departureCity, string arrivalCity);
    }
}
