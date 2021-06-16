using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class CityRepository : BaseRepository<CityEntity>, ICityRepository
    {
        public CityRepository(ReservationSystemContext context) : base(context, context.Cities)
        {
        }
    }
}
