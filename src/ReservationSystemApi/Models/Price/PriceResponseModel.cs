namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Price
{
    public class PriceResponseModel
    {
        public int Id { get; set; }

        public int AirplaneId { get; set; }

        public string AirplaneModel { get; set; }

        public string PlaceType { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
