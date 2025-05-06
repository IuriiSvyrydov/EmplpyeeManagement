using EmployeeMamagement.App.Extensions;
using EmployeeManagement.App.Extensions;
using EmployeeManagement.Application.Extensions;
using EmployeeManagement.Persistence.Extensions;
using EmployeeManagement.Persistence.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterIdentity();
builder.Services.RegisterController();
builder.Services.RegisterDatabase(builder.Configuration);
builder.Services.RegisterCors(builder.Configuration);
builder.Services.RegisterRepositories();
builder.Services.RegisterSwagger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterMediatr();
builder.Services.RegisterAutoMapper();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}
app.MapControllers();
app.UseCors("AllowUIOrigin");
app.UseAuthentication();



app.Run();
