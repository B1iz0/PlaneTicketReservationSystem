using System;

namespace PlaneTicketReservationSystem.Business.Models.SearchHints
{
    public class FlightHint
    {
        public Guid Id { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }
    }
}