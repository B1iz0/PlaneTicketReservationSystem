using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
