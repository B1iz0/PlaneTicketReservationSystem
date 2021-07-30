using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class FlightEntity
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }

        public string FlightNumber { get; set; }

        public Guid FromId { get; set; }
        public virtual AirportEntity From { get; set; }

        public Guid ToId { get; set; }
        public virtual AirportEntity To { get; set; }

        public DateTimeOffset DepartureTime { get; set; }

        public DateTimeOffset ArrivalTime { get; set; }

        public double FreeBaggageLimitInKilograms { get; set; }

        public decimal OverweightPrice { get; set; }

        public virtual List<BookingEntity> Bookings { get; set; }
    }
}
