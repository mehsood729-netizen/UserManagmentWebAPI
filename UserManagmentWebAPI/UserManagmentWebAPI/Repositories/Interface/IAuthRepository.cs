using UserManagmentWebAPI.Data.Entities;

namespace UserManagmentWebAPI.Repositories.Interface
{


    public interface IAuthRepository
    {
        Task<User> UserRegistration(User user);
        Task<User> LoginAsync(string Identifier);
    }

}
