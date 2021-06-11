using System.Collections.Generic;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IAirplaneService : IDataService<Airplane>
    {
        IEnumerable<Airplane> GetFreeAirplanes();

        IEnumerable<Airplane> GetFilteredAirplanes(int offset, int limit, string airplaneType, string company, string model);

        int GetFilteredAirplanesCount(string airplaneType, string company, string model);
    }
}
