using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPriceService : IDataService<Price>
    {
        Task<IEnumerable<Price>> GetByAirplaneIdAsync(int airplaneId);
    }
}