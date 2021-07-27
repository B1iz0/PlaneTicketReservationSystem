using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters
{
    public class FlightFilterModel
    {
        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}