using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CountryRepository : BaseRepository<CountryEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<CountryEntity> _countries;

        public CountryRepository(ReservationSystemContext context) : base(context, context.Countries)
        {
            _db = context;
            _countries = context.Countries;
        }
    }
}
