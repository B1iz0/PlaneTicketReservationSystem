using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
    }
}
