using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Booking
{
    public class BookingRegistrationModel
    {
        public Guid FlightId { get; set; }

        public Guid UserId { get; set; }

        public Guid PlaceId { get; set; }
    }
}
