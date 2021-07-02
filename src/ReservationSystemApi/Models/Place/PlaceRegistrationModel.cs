using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Place
{
    public class PlaceRegistrationModel
    {
        public Guid AirplaneId { get; set; }

        public Guid PlaceTypeId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
