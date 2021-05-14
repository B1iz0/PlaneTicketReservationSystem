namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels
{
    public class AirplaneRegistration
    {
        public int AirplaneTypeId { get; set; }
        public int CompanyId { get; set; }
        public int ModelNUmber { get; set; }
        public short RegistrationNumber { get; set; }
        public long Capacity { get; set; }
    }
}
