using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
