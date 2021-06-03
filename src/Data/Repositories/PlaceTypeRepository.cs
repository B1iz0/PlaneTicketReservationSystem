using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PlaceTypeRepository : BaseRepository<PlaceTypeEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<PlaceTypeEntity> _placeTypes;

        public PlaceTypeRepository(ReservationSystemContext context) : base(context, context.PlaceTypes)
        {
            _db = context;
            _placeTypes = _db.PlaceTypes;
        }
    }
}
