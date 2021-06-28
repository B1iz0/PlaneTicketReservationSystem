using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<Airport>> GetAllAsync();

        Task PostAsync(Airport item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Airport item);
    }
}