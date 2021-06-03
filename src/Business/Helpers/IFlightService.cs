using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IFlightService : IDataService<Flight>
    {
        public IEnumerable<Flight> GetFilteredFlights(int offset, int limit, string departureCity, string arrivalCity);

        public int GetFilteredFlightsCount(string departureCity, string arrivalCity);
    }
}
