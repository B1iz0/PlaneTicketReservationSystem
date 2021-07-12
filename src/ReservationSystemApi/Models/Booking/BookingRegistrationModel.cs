using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking
{
    public class BookingRegistrationModel
    {
        public Guid FlightId { get; set; }

        public Guid UserId { get; set; }

        public IEnumerable<Guid> PlacesId { get; set; }

        public double BaggageWeight { get; set; }
    }
}
