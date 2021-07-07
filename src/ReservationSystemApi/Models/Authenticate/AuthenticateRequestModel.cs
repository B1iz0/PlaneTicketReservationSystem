using System.ComponentModel.DataAnnotations;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Authenticate
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
