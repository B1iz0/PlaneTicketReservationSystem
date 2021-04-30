﻿using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityEntity> Cities { get; set; }
        public List<CompanyEntity> Companies { get; set; }
    }
}
