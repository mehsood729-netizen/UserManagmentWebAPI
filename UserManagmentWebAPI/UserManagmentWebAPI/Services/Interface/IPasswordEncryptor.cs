namespace UserManagmentWebAPI.Services.Interface
{
    public interface IPasswordEncryptor
    {
        void PasswordHashAndSalt(string password, out byte[] hash, out byte[] salt);
        bool VerifyPassword(string password, byte[] storedhash, byte[] storedSalt);
    }
}
