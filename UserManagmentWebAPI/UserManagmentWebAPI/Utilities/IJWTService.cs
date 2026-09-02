using UserManagmentWebAPI.Data.Entities;

namespace UserManagmentWebAPI.Utilities
{
    public interface IJWTService
    {
        string CreateJWT(User user);
    }
}
