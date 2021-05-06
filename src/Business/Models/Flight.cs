using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public long FlightNumber { get; set; }
        public int FromId { get; set; }
        public virtual Airport From { get; set; }
        public int ToId { get; set; }
        public virtual Airport To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ArrivalTime { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
