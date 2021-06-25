using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight
{
    public class FlightRegistrationModel
    {
        public int AirplaneId { get; set; }

        public string FlightNumber { get; set; }

        public int FromId { get; set; }

        public int ToId { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
    }
}
