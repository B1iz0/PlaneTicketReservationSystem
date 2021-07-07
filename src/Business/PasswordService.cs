using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Interfaces;

namespace PlaneTicketReservationSystem.Business
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordServiceSettings _serviceSettings;

        public PasswordService(IOptions<PasswordServiceSettings> providerSettings)
        {
            _serviceSettings = providerSettings.Value;
        }

        public string GenerateHash(string password, SHA256 sha256)
        {
            var passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var passwordHash = Convert.ToBase64String(passwordBytes);
            var result = new StringBuilder(passwordHash.Length + _serviceSettings.Salt.Length);
            result.Append(passwordHash);
            result.Append(_serviceSettings.Salt);
            return result.ToString();
        }

        public bool CheckHash(string password, string hash)
        {
            var passwordHash = GenerateHash(password, SHA256.Create());
            return hash == passwordHash;
        }
    }
}
