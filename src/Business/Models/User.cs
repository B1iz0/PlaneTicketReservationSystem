using System.Text.Json.Serialization;

namespace PlaneTicketReservationSystem.Business.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
