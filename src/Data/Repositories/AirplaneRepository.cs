using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneRepository : BaseRepository<AirplaneEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<AirplaneEntity> _airplanes;

        public AirplaneRepository(ReservationSystemContext context) : base(context, context.Airplanes)
        {
            _db = context;
            _airplanes = _db.Airplanes;
        }

        public IQueryable<AirplaneEntity> GetFreeAirplanes()
        {
            return _airplanes.Where(a => a.Flight == null);
        }
    }
}
