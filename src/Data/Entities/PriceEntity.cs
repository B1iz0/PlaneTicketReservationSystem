using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class PriceEntity
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }

        public Guid PlaceTypeId { get; set; }
        public virtual PlaceTypeEntity PlaceType { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
