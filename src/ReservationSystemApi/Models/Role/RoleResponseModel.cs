using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.User;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.Role
{
    public class RoleResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserResponseModel> Users { get; set; }
    }
}
