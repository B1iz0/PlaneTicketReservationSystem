using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<UserEntity> _users;

        public UserRepository(ReservationSystemContext context) : base(context, context.Users)
        {
            _db = context;
            _users = context.Users;
        }
    }
}
