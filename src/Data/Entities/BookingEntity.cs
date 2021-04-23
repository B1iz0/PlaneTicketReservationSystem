using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public FlightEntity Flight { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
