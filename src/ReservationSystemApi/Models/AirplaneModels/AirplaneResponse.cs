using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels
{
    public class AirplaneResponse
    {
        public int Id { get; set; }
        public AirplaneTypeResponse AirplaneType { get; set; }
        public CompanyResponse Company { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
