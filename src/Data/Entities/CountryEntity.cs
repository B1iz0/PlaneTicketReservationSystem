using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityEntity> Cities { get; set; } = new List<CityEntity>();
    }
}
