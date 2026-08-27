using Microsoft.EntityFrameworkCore;
using UserManagmentWebAPI.Data.Entities;

namespace UserManagmentWebAPI.Data
{
    public class UserManagementDbContext(DbContextOptions<UserManagementDbContext> dbContext) : DbContext(dbContext)
    {
        public DbSet<User> Users { get; set; }
    }
}
