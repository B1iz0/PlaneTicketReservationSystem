using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirplaneEntity
    {
        public int Id { get; set; }
        public int AirplaneTypeId { get; set; }
        public AirplaneTypeEntity AirplaneType { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
