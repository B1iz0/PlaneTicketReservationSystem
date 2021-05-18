using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceTypeModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.PriceModels
{
    public class PriceResponse
    {
        public int Id { get; set; }
        public int AirplaneId { get; set; }
        public string AirplaneModel { get; set; }
        public string PlaceType { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
