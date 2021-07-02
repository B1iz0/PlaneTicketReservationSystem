using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class PlaceListRegistration
    {
        public Guid AirplaneId { get; set; }

        public IEnumerable<PlaceRegistration> Places { get; set; }
    }
}
