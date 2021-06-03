using System.Threading.Tasks;
using PlaneTicketReservationSystem.Business.Models;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IAccountService
    {
        public Task<Authenticate> AuthenticateAsync(Authenticate model);

        public Task<Authenticate> RefreshTokenAsync(string token);

        public Task<bool> RevokeTokenAsync(string token);

        public Task<string> GenerateJwtTokenAsync(User user);

        public RefreshToken GenerateRefreshToken();
    }
}
