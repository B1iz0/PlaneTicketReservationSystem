using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class PlaceTypeRepository : BaseRepository<PlaceTypeEntity>, IPlaceTypeRepository
    {
        public PlaceTypeRepository(ReservationSystemContext context) : base(context, context.PlaceTypes)
        {
        }
    }
}
