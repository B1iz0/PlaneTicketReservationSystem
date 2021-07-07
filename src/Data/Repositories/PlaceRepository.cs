using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PlaceRepository : BaseRepository<PlaceEntity>, IPlaceRepository
    {
        public PlaceRepository(ReservationSystemContext context) : base(context, context.Places)
        {
        }
    }
}
