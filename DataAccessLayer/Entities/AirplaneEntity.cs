using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class AirplaneEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AirplaneTypeId { get; set; }
        [ForeignKey("AirplaneTypeId")]
        public AirplaneTypeEntity AirplaneType { get; set; }
        public int ModelNumber { get; set; }
        [Required]
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
