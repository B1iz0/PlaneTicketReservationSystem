using Microsoft.EntityFrameworkCore;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PriceRepository : BaseRepository<PriceEntity>
    {
        private readonly ReservationSystemContext _db;

        private readonly DbSet<PriceEntity> _prices;

        public PriceRepository(ReservationSystemContext context) : base(context, context.Prices)
        {
            _db = context;
            _prices = _db.Prices;
        }
    }
}
