using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class FlightRepository : BaseRepository<FlightEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<FlightEntity> _flights;

        public FlightRepository(ReservationSystemContext context) : base(context, context.Flights)
        {
            _db = context;
            _flights = context.Flights;
        }
    }
}
