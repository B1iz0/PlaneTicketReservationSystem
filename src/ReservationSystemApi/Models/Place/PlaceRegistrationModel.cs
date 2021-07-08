using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Place
{
    public class PlaceRegistrationModel
    {
        public Guid PlaceTypeId { get; set; }

        public string PlaceTypeName { get; set; }

        public int PlaceAmount { get; set; }
    }
}
