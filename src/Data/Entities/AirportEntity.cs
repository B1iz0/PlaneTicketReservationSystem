using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirportEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public CityEntity City { get; set; }
    }
}
