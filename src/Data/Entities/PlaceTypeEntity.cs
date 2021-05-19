using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class PlaceTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<PlaceEntity> Places { get; set; }
        public virtual List<PriceEntity> Prices { get; set; }
    }
}
