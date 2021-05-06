using System;
using System.Collections.Generic;
using System.Text;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Services.RoleService
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        void Post(Role role);
        void Delete(int id);
        void Update(int id, Role role);
    }
}
