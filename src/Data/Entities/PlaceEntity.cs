namespace PlaneTicketReservationSystem.Data.Entities
{
    public class PlaceEntity
    {
        public int Id { get; set; }
        public int AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }
        public int PlaceTypeId { get; set; }
        public virtual PlaceTypeEntity PlaceType { get; set; }
        public int? PriceId { get; set; }
        public virtual PriceEntity Price { get; set; }
        public virtual BookingEntity Booking { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
