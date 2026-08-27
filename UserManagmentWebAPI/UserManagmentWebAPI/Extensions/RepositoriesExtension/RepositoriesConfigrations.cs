using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserManagmentWebAPI.Data;
using UserManagmentWebAPI.Repositories.Implementation;
using UserManagmentWebAPI.Repositories.Interface;

namespace UserManagmentWebAPI.Extensions.RepositoriesExtension
{
    public static class RepositoriesConfigrations
    {
        public static IServiceCollection MyRepo(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<UserManagementDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("myWebAPIConn")))
            .AddScoped<IAuthRepository, AuthRepository>();
    }
}
