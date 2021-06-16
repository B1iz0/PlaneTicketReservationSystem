using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PriceRepository : BaseRepository<PriceEntity>, IPriceRepository
    {
        public PriceRepository(ReservationSystemContext context) : base(context, context.Prices)
        {
        }
    }
}
