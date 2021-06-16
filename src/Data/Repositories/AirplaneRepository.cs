using System.Linq;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneRepository : BaseRepository<AirplaneEntity>, IAirplaneRepository
    {
        public AirplaneRepository(ReservationSystemContext context) : base(context, context.Airplanes)
        {
        }

        public IQueryable<AirplaneEntity> GetFreeAirplanes()
        {
            return DbSet.Where(airplane => airplane.Flight == null);
        }
    }
}
