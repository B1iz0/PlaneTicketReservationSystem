using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints
{
    public class FlightHintModel
    {
        public Guid Id { get; set; }

        public string DepartureCity { get; set; }

        public string ArrivalCity { get; set; }
    }
}