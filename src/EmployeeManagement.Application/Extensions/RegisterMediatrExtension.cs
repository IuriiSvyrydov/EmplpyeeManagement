using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace EmployeeManagement.Application.Extensions
{
    public static class RegisterMediatrExtension
    {
        public static IServiceCollection RegisterMediatr(this IServiceCollection services)
        {
            services.AddMediatR(x=>x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}