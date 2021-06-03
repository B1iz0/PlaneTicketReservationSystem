using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class FlightEntity
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }

        public long FlightNumber { get; set; }

        public int FromId { get; set; }
        public virtual AirportEntity From { get; set; }

        public int ToId { get; set; }
        public virtual AirportEntity To { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime ArrivalTime { get; set; }

        public virtual List<BookingEntity> Bookings { get; set; }
    }
}
