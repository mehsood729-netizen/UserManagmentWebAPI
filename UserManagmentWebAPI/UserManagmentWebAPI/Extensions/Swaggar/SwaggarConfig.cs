using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace UserManagmentWebAPI.Extensions.Swaggar
{
    public static class SwaggarConfig
    {
        public static IServiceCollection SwaggarConfigration(this IServiceCollection services) =>
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UserManagmentAPI",
                    Version = "v1",
                });
                option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                   Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Please enter JWT with Breare into fields. Example Bearer {token}"
                });
                option.OperationFilter<SecurityRequirementsOperationFilter>();
                
            });


        public static IServiceCollection AuthenticationConfig(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = "www.OCMS.Com",
                        ValidAudience = "ThisTokenONLYvalidForOCMSUsers",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["APIToken"]!)),
                        ValidateIssuer = true,
                        ValidateLifetime = true
                    };

                });
            return services;

        }
    }
}
