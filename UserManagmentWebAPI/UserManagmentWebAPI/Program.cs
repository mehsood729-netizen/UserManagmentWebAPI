using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.RepositoriesExtension;
using UserManagmentWebAPI.Extensions.ServicesExtension;
using UserManagmentWebAPI.Extensions.Swaggar;
using UserManagmentWebAPI.Extensions.Validator;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();



builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<ValidateUserRegisterDTO>()
    .AddValidatorsFromAssemblyContaining<ValidateLoginDTO>()
    .SwaggarConfigration()
    .JwtConfigration()
    .MyRepo(builder.Configuration)
    .MyServices();




var app = builder.Build();
app.MiddlewareConfig();

app.Run();


