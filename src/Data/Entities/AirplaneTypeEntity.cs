using System.ComponentModel.DataAnnotations;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneTypeEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
