using EmployeeManagement.App.Extensions;
using EmployeeManagement.Persistence.Extensions;
using EmployeeManagement.Persistence.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterIdentity();
builder.Services.RegisterDatabase(builder.Configuration);
builder.Services.RegisterCors(builder.Configuration);

var app = builder.Build();
app.UseCors("AllowUIOrigin");
app.UseAuthentication();


app.Run();
