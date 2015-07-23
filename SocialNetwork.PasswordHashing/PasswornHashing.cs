using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace SocialNetwork.PasswordHashing
{
    public static class PasswordHashing
    {
        private static byte SaltValueSize = 32;
        public static string GenerateSaltValue() 
        {
            var generator = RandomNumberGenerator.Create();
            byte[] saltValue = new byte[SaltValueSize];
            generator.GetBytes(saltValue);
            return Convert.ToBase64String(saltValue);
        }

        public static string HashPassword(string password, string saltValue)
        {
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Password is null");
            
            var encoding = new UnicodeEncoding();           
            var hash = new SHA256CryptoServiceProvider();
            
            if (saltValue == null)
            {
                saltValue = GenerateSaltValue();
            }

            byte[] binarySaltValue = Convert.FromBase64String(saltValue);
            byte[] valueToHash = new byte[SaltValueSize + encoding.GetByteCount(password)];
            byte[] binaryPassword = encoding.GetBytes(password);

            binarySaltValue.CopyTo(valueToHash, 0);
            binaryPassword.CopyTo(valueToHash, SaltValueSize);

            byte[] hashValue = hash.ComputeHash(valueToHash);
            var hashedPassword = String.Empty;
            foreach (byte hexdigit in hashValue)
            {
                hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
            }

            return hashedPassword;
        }
    }
}
