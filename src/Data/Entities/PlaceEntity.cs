using System;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class PlaceEntity
    {
        public Guid Id { get; set; }

        public Guid AirplaneId { get; set; }
        public virtual AirplaneEntity Airplane { get; set; }

        public Guid PlaceTypeId { get; set; }
        public virtual PlaceTypeEntity PlaceType { get; set; }

        public virtual BookingEntity Booking { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
