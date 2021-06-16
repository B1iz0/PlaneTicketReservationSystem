using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(ReservationSystemContext context) : base(context, context.Roles)
        {
        }
    }
}
