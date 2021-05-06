using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneTypeEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public virtual List<AirplaneEntity> Airplanes { get; set; }
    }
}
