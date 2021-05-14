using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels
{
    public class AirplaneTypeDetails
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public List<AirplaneResponse> Airplanes { get; set; }
    }
}
