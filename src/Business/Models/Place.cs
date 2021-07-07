using System;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Place
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public Guid PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }

        public Guid? PriceId { get; set; }
        public Price Price { get; set; }

        public Booking Booking { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
