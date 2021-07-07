using System;
using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPlaceService
    {
        Task<Place> GetByIdAsync(Guid id);

        Task PostAsync(PlaceListRegistration item);
    }
}