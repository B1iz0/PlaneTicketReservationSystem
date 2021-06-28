using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Price
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public Guid PlaceTypeId { get; set; }
        public PlaceType PlaceType { get; set; }

        public decimal TicketPrice { get; set; }

        public List<Place> Places { get; set; }
    }
}
