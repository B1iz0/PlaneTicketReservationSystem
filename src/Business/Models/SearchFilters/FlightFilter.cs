using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchFilters
{
    public class FlightFilter
    {
        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}