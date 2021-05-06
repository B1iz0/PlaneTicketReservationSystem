using System;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
