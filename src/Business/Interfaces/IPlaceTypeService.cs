using System.Collections.Generic;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPlaceTypeService
    {
        Task<IEnumerable<PlaceType>> GetAllAsync();

        Task PostAsync(PlaceType item);

        Task UpdateAsync(int id, PlaceType item);
    }
}