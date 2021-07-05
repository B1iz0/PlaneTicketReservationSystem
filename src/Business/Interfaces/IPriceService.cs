using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPriceService
    {
        IEnumerable<Price> GetByAirplaneIdAsync(Guid airplaneId);

        Task PostAsync(Price item);

        Task UpdateAsync(Guid id, Price item);

        Task UpdateListAsync(IEnumerable<Price> prices);
    }
}