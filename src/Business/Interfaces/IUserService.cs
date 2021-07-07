using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetFilteredUsers(int offset, int limit, string email, string firstName, string lastName);
        
        int GetFilteredUsersCount(string email, string firstName, string lastName);

        Task<User> GetByIdAsync(Guid id);

        Task PostAsync(User user);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, User user);
    }
}
