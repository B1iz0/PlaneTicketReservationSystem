using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Flight
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public string FlightNumber { get; set; }

        public Guid FromId { get; set; }
        public Airport From { get; set; }

        public Guid ToId { get; set; }
        public Airport To { get; set; }

        public DateTimeOffset DepartureTime { get; set; }

        public DateTimeOffset ArrivalTime { get; set; }

        public double FreeBaggageLimitInKilograms { get; set; }

        public decimal OverweightPrice { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
