using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.RepositoriesExtension;
using UserManagmentWebAPI.Extensions.ServicesExtension;
using UserManagmentWebAPI.Extensions.Swaggar;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.SwaggarConfigration();
builder.Services.MyRepo(builder.Configuration);
builder.Services.MyServices();
var app = builder.Build();
app.MiddlewareConfig();

app.Run();


