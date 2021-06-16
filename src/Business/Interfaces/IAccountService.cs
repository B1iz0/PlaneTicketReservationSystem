using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IAccountService
    {
        Task<Authenticate> AuthenticateAsync(Authenticate model);

        Task<Authenticate> RefreshTokenAsync(string token);

        Task<string> GenerateJwtTokenAsync(User user);

        RefreshToken GenerateRefreshToken();
    }
}
