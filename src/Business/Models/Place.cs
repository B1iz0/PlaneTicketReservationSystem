namespace PlaneTicketReservationSystem.Business.Models
{
    public class Place
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public int PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }

        public int? PriceId { get; set; }
        public Price Price { get; set; }

        public Booking Booking { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
