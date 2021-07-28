using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAirplaneService
    {
        Task<Airplane> GetByIdAsync(Guid id);

        Task<Airplane> PostAsync(Airplane item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(Guid id, Airplane item);

        IEnumerable<Airplane> GetFreeAirplanes();

        IEnumerable<Airplane> GetFilteredAirplanes(AirplaneFilter filter, int offset, int limit);

        int GetFilteredAirplanesCount(AirplaneFilter filter);

        IEnumerable<AirplaneHint> GetHints(AirplaneFilter filter, int offset, int limit);
    }
}
