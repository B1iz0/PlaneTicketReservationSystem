using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IUserService : IDataService<User>
    {
        IEnumerable<User> GetFilteredUsers(int offset, int limit, string email, string firstName, string lastName);
        int GetFilteredUsersCount(string email, string firstName, string lastName);
    }
}
