using UserManagmentWebAPI.Data.Entities;
using UserManagmentWebAPI.Repositories.Interface;

namespace UserManagmentWebAPI.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        public Task<User> LoginAsync(string Identifier)
        {
            throw new NotImplementedException();
        }

        public Task<User> UserRegistration(User user)
        {
            throw new NotImplementedException();
        }
    }
}
