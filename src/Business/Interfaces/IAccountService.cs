using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAccountService
    {
        Task<Authenticate> AuthenticateAsync(Authenticate model);
    }
}
