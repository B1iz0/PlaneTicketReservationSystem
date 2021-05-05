using System.Text.Json.Serialization;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
