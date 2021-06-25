using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPlaceService
    {
        Task<Place> GetByIdAsync(int id);

        Task PostAsync(Place item);
    }
}