using System.Security.Cryptography;

namespace PlaneTicketReservationSystem.Data
{
    public interface IPasswordProvider
    {
        string GenerateHash(string password, SHA256 sha256);

        bool CheckHash(string password, string hash);
    }
}