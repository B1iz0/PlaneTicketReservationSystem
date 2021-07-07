using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class FlightRepository : BaseRepository<FlightEntity>, IFlightRepository
    {
        public FlightRepository(ReservationSystemContext context) : base(context, context.Flights)
        {
        }
    }
}
