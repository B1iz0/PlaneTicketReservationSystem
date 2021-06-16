using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface ITokenProvider
    {
        Task<string> GenerateJwtTokenAsync(User user);

        RefreshToken GenerateRefreshToken();

        Task<Authenticate> RefreshTokenAsync(string token);
    }
}
