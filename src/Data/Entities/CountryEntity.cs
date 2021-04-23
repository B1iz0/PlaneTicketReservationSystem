using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class CountryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<CityEntity> Cities { get; set; } = new List<CityEntity>();
    }
}
