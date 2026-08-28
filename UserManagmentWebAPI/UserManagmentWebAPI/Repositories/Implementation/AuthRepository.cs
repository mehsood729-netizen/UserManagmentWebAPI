using Microsoft.EntityFrameworkCore;
using UserManagmentWebAPI.Data;
using UserManagmentWebAPI.Data.Entities;
using UserManagmentWebAPI.Repositories.Interface;

namespace UserManagmentWebAPI.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManagementDbContext _dbContext;
        public AuthRepository(UserManagementDbContext user)
        {
            _dbContext = user;
        }
        public async Task<User> LoginAsync(string Identifier)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == Identifier || x.UserName == Identifier || x.Contact == Identifier);
            return existingUser!;
        }

        public async Task<User> UserRegistration(User user)
        {
            var userExist = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName || x.Email == user.Email || x.Contact == user.Contact);
            if (userExist is null)
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            return userExist;
        }
    }
}
