using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetFreeUsers();

        IEnumerable<User> GetFilteredUsers(UserFilter filter, int offset, int limit);
        
        int GetFilteredUsersCount(UserFilter filter);

        Task<User> GetByIdAsync(Guid id);

        IEnumerable<User> GetManagers(Guid companyId);

        Task PostAsync(User user);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, User user);

        Task AssignCompanyAsync(Guid id, Guid? companyId);

        IEnumerable<UserHint> GetHints(UserFilter filter, int offset, int limit);
    }
}
