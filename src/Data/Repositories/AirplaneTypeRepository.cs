using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;
using PlaneTicketReservationSystem.Data.Repositories.BaseRepository;

namespace PlaneTicketReservationSystem.Data.Repositories
{
    public class AirplaneTypeRepository : BaseRepository<AirplaneTypeEntity>, IAirplaneTypeRepository
    {
        public AirplaneTypeRepository(ReservationSystemContext context) : base(context, context.AirplaneTypes)
        {
        }
    }
}
