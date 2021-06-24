using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneType;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Place;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Price;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane
{
    public class AirplaneResponseModel
    {
        public int Id { get; set; }

        public AirplaneTypeResponseModel AirplaneType { get; set; }

        public CompanyResponseModel Company { get; set; }

        public FlightResponseModel Flight { get; set; }

        public string Model { get; set; }

        public int RegistrationNumber { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public List<PlaceResponseModel> Places { get; set; }

        public List<PriceResponseModel> Prices { get; set; }
    }
}
