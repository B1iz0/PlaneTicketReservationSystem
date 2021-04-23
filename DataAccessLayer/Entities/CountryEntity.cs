using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
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
