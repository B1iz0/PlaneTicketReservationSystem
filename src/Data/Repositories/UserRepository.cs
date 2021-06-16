using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ReservationSystemContext context) : base(context, context.Users)
        {
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
