using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels
{
    public class AirplaneDetails
    {
        public int Id { get; set; }
        public AirplaneTypeResponse AirplaneType { get; set; }
        public CompanyResponse Company { get; set; }
        public FlightResponse Flight { get; set; }
        public int ModelNumber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
