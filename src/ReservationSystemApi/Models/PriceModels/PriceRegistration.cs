namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.PriceModels
{
    public class PriceRegistration
    {
        public int AirplaneId { get; set; }
        public int PlaceTypeId { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
