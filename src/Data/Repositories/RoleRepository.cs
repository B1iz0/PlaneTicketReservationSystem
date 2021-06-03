using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<RoleEntity> _roles;

        public RoleRepository(ReservationSystemContext context) : base(context, context.Roles)
        {
            _db = context;
            _roles = context.Roles;
        }
    }
}
