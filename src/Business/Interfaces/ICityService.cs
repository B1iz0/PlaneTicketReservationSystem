using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllAsync();

        Task PostAsync(City item);

        Task UpdateAsync(int id, City item);

    }
}