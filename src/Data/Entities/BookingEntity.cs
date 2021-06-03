namespace PlaneTicketReservationSystem.Data.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }

        public int FlightId { get; set; }
        public virtual FlightEntity Flight { get; set; }

        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public int PlaceId { get; set; }
        public virtual PlaceEntity Place { get; set; }
    }
}
