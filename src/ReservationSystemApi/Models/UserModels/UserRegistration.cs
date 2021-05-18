using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels
{
    public class UserRegistration
    {
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserRegistration()
        {
            RoleId = 3;
        }
    }
}
