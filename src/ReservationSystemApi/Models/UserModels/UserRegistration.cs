namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
