using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace PlaneTicketReservationSystem.Data
{
    public class PasswordProvider : IPasswordProvider
    {
        private readonly PasswordProviderSettings _providerSettings;

        public PasswordProvider(IOptions<PasswordProviderSettings> providerSettings)
        {
            _providerSettings = providerSettings.Value;
        }

        public string GenerateHash(string password, SHA256 sha256)
        {
            var passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var passwordHash = Convert.ToBase64String(passwordBytes);
            var result = new StringBuilder(passwordHash.Length + _providerSettings.Salt.Length);
            result.Append(passwordHash);
            result.Append(_providerSettings.Salt);
            return result.ToString();
        }

        public bool CheckHash(string password, string hash)
        {
            var passwordHash = GenerateHash(password, SHA256.Create());
            return hash == passwordHash;
        }
    }
}
