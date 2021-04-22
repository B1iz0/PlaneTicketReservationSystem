using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class AirplaneType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
