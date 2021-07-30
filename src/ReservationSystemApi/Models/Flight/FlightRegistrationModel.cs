using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight
{
    public class FlightRegistrationModel
    {
        public Guid AirplaneId { get; set; }

        public string FlightNumber { get; set; }

        public Guid FromId { get; set; }

        public Guid ToId { get; set; }

        public DateTimeOffset DepartureTime { get; set; }

        public DateTimeOffset ArrivalTime { get; set; }

        public double FreeBaggageLimitInKilograms { get; set; }

        public decimal OverweightPrice { get; set; }
    }
}
