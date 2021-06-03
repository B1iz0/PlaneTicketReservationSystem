using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Price
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public int PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }

        public decimal TicketPrice { get; set; }

        public List<Place> Places { get; set; }
    }
}
