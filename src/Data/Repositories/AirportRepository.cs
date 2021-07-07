using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirportRepository : BaseRepository<AirportEntity>, IAirportRepository
    {
        public AirportRepository(ReservationSystemContext context) : base(context, context.Airports)
        {
        }
    }
}
