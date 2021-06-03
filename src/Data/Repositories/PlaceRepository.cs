using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PlaceRepository : BaseRepository<PlaceEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<PlaceEntity> _places;

        public PlaceRepository(ReservationSystemContext context) : base(context, context.Places)
        {
            _db = context;
            _places = _db.Places;
        }
    }
}
