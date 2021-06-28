using System.Security.Cryptography;

namespace PlaneTicketReservationSystem.Business.Interfaces
{
    public interface IPasswordService
    {
        string GenerateHash(string password, SHA256 sha256);

        bool CheckHash(string password, string hash);
    }
}