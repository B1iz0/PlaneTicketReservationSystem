using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserEntity> GetAll();
        User GetById(int id);
        void Post(User user);
        void Delete(int id);
    }
}
