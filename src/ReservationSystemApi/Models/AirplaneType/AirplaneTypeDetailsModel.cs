using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneType
{
    public class AirplaneTypeDetailsModel
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public List<AirplaneResponseModel> Airplanes { get; set; }
    }
}
