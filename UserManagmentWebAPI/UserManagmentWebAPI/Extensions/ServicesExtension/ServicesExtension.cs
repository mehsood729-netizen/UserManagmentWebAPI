using Microsoft.Extensions.DependencyInjection;
using UserManagmentWebAPI.Services.Implementation;
using UserManagmentWebAPI.Services.Interface;

namespace UserManagmentWebAPI.Extensions.ServicesExtension
{
    public static class ServicesExtension
    {
        public static IServiceCollection MyServices(this IServiceCollection services) => services
            .AddScoped<IAuthenticationServices, AuthenticationServices>()
            .AddScoped<IPasswordEncryptor, PasswordEncryptor>();
    }
}
