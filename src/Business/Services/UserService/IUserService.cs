using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Services.UserService
{
    public interface IUserService
    {
        string Authenticate(Authenticate model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Post(User user);
        void Delete(int id);
    }
}
