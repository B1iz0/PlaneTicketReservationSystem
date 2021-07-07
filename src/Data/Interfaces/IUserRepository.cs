using System.Threading.Tasks;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Data.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetByEmailAsync(string email);
    }
}