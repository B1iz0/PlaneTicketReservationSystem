using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPriceService
    {
        Task<IEnumerable<Price>> GetByAirplaneIdAsync(int airplaneId);

        Task PostAsync(Price item);

        Task UpdateAsync(int id, Price item);
    }
}