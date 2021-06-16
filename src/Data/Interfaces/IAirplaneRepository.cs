using System.Linq;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Data.Interfaces
{
    public interface IAirplaneRepository : IRepository<AirplaneEntity>
    {
        IQueryable<AirplaneEntity> GetFreeAirplanes();
    }
}
