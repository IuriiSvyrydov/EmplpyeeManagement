using AssemblyReference = EmployeeManagement.App.AssemblyReference;

namespace EmployeeMamagement.App.Extensions
{
    public static class RegisterControllerExtension
    {
        public static IServiceCollection RegisterController(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(EmployeeManagement.Presentation.AssemblyReference).Assembly);
            return services; 

        }
    }
}
