using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class AirplaneType
    {
        public Guid Id { get; set; }

        public string TypeName { get; set; }

        public List<Airplane> Airplanes { get; set; }
    }
}
