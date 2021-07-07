using System;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Booking
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
