using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetByIdAsync(int id);

        Task PostAsync(Booking item);

        Task DeleteAsync(int id);
    }
}