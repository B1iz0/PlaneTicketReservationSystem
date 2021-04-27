namespace PlaneTicketReservationSystem.Data.Entities
{
    public class AirportEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityEntity City { get; set; }
    }
}
