using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirportRepository : BaseRepository<AirportEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<AirportEntity> _airports;

        public AirportRepository(ReservationSystemContext context) : base(context, context.Airports)
        {
            _db = context;
            _airports = context.Airports;
        }
    }
}
