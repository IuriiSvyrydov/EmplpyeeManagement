using EmployeeManagement.App;
using System.Reflection.Metadata;
using AssemblyReference = EmployeeManagement.App.AssemblyReference;

namespace EmployeeManagement.App.Extensions
{
    public static class RegisterControllerExtension
    {
        public static IServiceCollection RegisterController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(AssemblyReference.assembly);
            return services; 

        }
    }
}
