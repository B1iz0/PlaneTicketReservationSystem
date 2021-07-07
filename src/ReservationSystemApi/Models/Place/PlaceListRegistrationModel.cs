using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Place
{
    public class PlaceListRegistrationModel
    {
        public Guid AirplaneId { get; set; }

        public IEnumerable<PlaceRegistrationModel> Places { get; set; }
    }
}
