using System;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetByIdAsync(Guid id);

        Task<Guid> PostAsync(Booking item);

        Task DeleteAsync(Guid id);
    }
}