using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CityRepository : BaseRepository<CityEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<CityEntity> _cities;

        public CityRepository(ReservationSystemContext context) : base(context, context.Cities)
        {
            _db = context;
            _cities = context.Cities;
        }
    }
}
