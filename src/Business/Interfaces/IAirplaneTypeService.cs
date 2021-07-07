using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirplaneTypeService
    {
        Task<IEnumerable<AirplaneType>> GetAllAsync();

        Task PostAsync(AirplaneType item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, AirplaneType item);
    }
}