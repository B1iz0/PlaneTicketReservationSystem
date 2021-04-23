using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CityEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public CountryEntity Country { get; set; }
        public List<AirportEntity> Airports { get; set; } = new List<AirportEntity>();
    }
}
