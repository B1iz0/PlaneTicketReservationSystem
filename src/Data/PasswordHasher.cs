using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PlaneTicketReservationSystem.Data
{
    public class PasswordHasher
    {
        private const int SaltLength = 32;
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

        public static string GenerateSalt(int saltLength)
        {
            var salt = new byte[saltLength];
            var random = new RNGCryptoServiceProvider();
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        //public static bool CheckHash(string password, string hash)
        //{
        //    var passwordHash = GenerateHash(password, , SHA256.Create());
        //    return hash == passwordHash;
        //}
    }
}
