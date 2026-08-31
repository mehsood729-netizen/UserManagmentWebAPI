using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.RepositoriesExtension;
using UserManagmentWebAPI.Extensions.ServicesExtension;
using UserManagmentWebAPI.Extensions.Swaggar;
using UserManagmentWebAPI.Extensions.Validator;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.SwaggarConfigration();

builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<ValidateUserRegisterDTO>();


builder.Services.MyRepo(builder.Configuration);
builder.Services.MyServices();
var app = builder.Build();
app.MiddlewareConfig();

app.Run();


