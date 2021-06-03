using System.Collections.Generic;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels
{
    public class RoleResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserResponse> Users { get; set; }
    }
}
