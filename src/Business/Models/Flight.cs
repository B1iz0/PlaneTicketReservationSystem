using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Flight
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public string FlightNumber { get; set; }

        public int FromId { get; set; }
        public Airport From { get; set; }

        public int ToId { get; set; }
        public Airport To { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
