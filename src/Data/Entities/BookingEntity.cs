using System;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class BookingEntity
    {
        public Guid Id { get; set; }

        public Guid FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }

        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public Guid PlaceId { get; set; }
        public virtual PlaceEntity Place { get; set; }
    }
}
