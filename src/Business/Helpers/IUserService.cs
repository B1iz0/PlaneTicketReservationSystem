using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IUserService : IDataService<User>
    {
        public IEnumerable<User> GetFilteredUsers(int offset, int limit, string email, string firstName, string lastName);
        public int GetFilteredUsersCount(string email, string firstName, string lastName);
    }
}
