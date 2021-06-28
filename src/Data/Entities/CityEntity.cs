using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CityEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public virtual CountryEntity Country { get; set; }

        public virtual List<AirportEntity> Airports { get; set; }
    }
}
