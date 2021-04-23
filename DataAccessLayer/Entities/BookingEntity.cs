

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class BookingEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int FlightId { get; set; }
        [ForeignKey("FlightId")]
        public FlightEntity Flight { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
