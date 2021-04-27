using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityEntity> Cities { get; set; } = new List<CityEntity>();
        public List<CompanyEntity> Companies { get; set; } = new List<CompanyEntity>();
    }
}
