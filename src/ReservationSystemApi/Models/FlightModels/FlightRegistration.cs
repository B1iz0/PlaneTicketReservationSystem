using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels
{
    public class FlightRegistration
    {
        public int AirplaneId { get; set; }

        public long FlightNumber { get; set; }

        public int FromId { get; set; }

        public int ToId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
