using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public IEnumerable<User> Admins { get; set; }

        public List<Airplane> Airplanes { get; set; }

        public List<Airport> Airports { get; set; }
    }
}
