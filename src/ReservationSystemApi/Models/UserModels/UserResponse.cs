namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
