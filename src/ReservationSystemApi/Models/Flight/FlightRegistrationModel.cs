using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight
{
    public class FlightRegistrationModel
    {
        public Guid AirplaneId { get; set; }

        public string FlightNumber { get; set; }

        public Guid FromId { get; set; }

        public Guid ToId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
