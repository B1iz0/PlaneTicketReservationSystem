using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class PriceEntity
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }

        public int PlaceTypeId { get; set; }
        public virtual PlaceTypeEntity PlaceType { get; set; }

        public decimal TicketPrice { get; set; }

        public virtual List<PlaceEntity> Places { get; set; }
    }
}
