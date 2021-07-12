using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Guid> PlacesId { get; set; }
        public IEnumerable<Place> Places { get; set; }

        public double BaggageWeight { get; set; }
    }
}
