using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Airplane
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AirplaneTypeId { get; set; }
        [ForeignKey("AirplaneTypeId")]
        public AirplaneType AirplaneType { get; set; }
        public int ModelNumber { get; set; }
        [Required]
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
