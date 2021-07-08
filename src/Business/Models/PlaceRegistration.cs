using System;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class PlaceRegistration
    {
        public Guid PlaceTypeId { get; set; }

        public string PlaceTypeName { get; set; }

        public int PlaceAmount { get; set; }
    }
}
