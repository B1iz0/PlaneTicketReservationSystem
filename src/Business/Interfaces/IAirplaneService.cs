using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirplaneService
    {
        Task<Airplane> GetByIdAsync(Guid id);

        Task PostAsync(Airplane item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Airplane item);

        IEnumerable<Airplane> GetFreeAirplanes();

        IEnumerable<Airplane> GetFilteredAirplanes(int offset, int limit, string airplaneType, string company, string model);

        int GetFilteredAirplanesCount(string airplaneType, string company, string model);
    }
}
