using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Country
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<City> Cities { get; set; }

        public List<Company> Companies { get; set; }
    }
}
