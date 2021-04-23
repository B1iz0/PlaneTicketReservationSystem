using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class FlightEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AirplaneId { get; set; }
        [ForeignKey("AirplaneId")]
        public AirplaneEntity Airplane { get; set; }
        [Required]
        public long FlightNumber { get; set; }
        [Required]
        public int FromId { get; set; }
        [Required]
        public int ToId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<BookingEntity> Bookings { get; set; }
    }
}
