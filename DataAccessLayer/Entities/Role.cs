using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
