using System;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Place
{
    public class PlaceResponseModel
    {
        public Guid Id { get; set; }

        public string PlaceType { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsFree { get; set; }
    }
}
