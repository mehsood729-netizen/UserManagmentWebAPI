using Microsoft.Extensions.DependencyInjection;
using UserManagmentWebAPI.Services.Implementation;
using UserManagmentWebAPI.Services.Interface;
using UserManagmentWebAPI.Utilities;

namespace UserManagmentWebAPI.Extensions.ServicesExtension
{
    public static class ServicesExtension
    {
        public static IServiceCollection JwtConfigration(this IServiceCollection services) => services.AddScoped<IJWTService, JWTService>();
        public static IServiceCollection MyServices(this IServiceCollection services) => services
            .AddScoped<IAuthenticationServices, AuthenticationServices>()
            .AddScoped<IPasswordEncryptor, PasswordEncryptor>();
    }
}
