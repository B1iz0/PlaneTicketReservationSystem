using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using System.Threading.Tasks;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public class TokenProvider : ITokenProvider
    {
        public Task<string> GenerateJwtTokenAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public RefreshToken GenerateRefreshToken()
        {
            throw new System.NotImplementedException();
        }

        public Task<Authenticate> RefreshTokenAsync(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
