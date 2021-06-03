using System;
using System.Security.Cryptography;
using System.Text;

namespace PlaneTicketReservationSystem.Data
{
    public class PasswordHasher
    {
        public static string Salt;

        public static string GenerateHash(string password, string salt, SHA256 sha256)
        {
            var passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            string passwordHash = Convert.ToBase64String(passwordBytes);
            StringBuilder result = new StringBuilder(passwordHash.Length + salt.Length);
            result.Append(passwordHash);
            result.Append(salt);
            return result.ToString();
        }

        public static bool CheckHash(string password, string hash)
        {
            var passwordHash = GenerateHash(password, Salt, SHA256.Create());
            return hash == passwordHash;
        }
    }
}
