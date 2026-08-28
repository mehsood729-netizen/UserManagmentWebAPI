using System.Security.Cryptography;
using System.Text;
using UserManagmentWebAPI.Services.Interface;

namespace UserManagmentWebAPI.Services.Implementation
{
    public class PasswordEncryptor : IPasswordEncryptor
    {
        public void PasswordHashAndSalt(string password, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPassword(string password, byte[] storedhash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var computedHash = hmac.ComputeHash(passwordBytes);
            return computedHash.SequenceEqual(storedhash);

        }
    }
}
