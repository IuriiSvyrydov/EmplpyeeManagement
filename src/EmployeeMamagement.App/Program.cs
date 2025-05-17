using EmployeeMamagement.App.Extensions;
using EmployeeManagement.Application.Extensions;
using EmployeeManagement.Persistence.Extensions;
using EmployeeManagement.Persistence.Identity;
using EmployeeManagement.Application.Middlewares;

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
builder.Services.RegisterValidation(); 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateDepartmentCommandHandler>());
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.ConfigureSwagger();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowUIOrigin");
app.UseAuthentication();



app.Run();
