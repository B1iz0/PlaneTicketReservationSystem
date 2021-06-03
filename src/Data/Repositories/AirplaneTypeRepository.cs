using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneTypeRepository : BaseRepository<AirplaneTypeEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<AirplaneTypeEntity> _airplaneTypes;

        public AirplaneTypeRepository(ReservationSystemContext context) : base(context, context.AirplaneTypes)
        {
            _db = context;
            _airplaneTypes = context.AirplaneTypes;
        }
    }
}
