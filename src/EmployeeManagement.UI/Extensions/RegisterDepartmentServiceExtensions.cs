using EmployeeManagement.UI.Services.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Extensions
{
    public static class RegisterDepartmentServiceExtensions
    {
        public static IServiceCollection RegisterDepartmentService(this IServiceCollection services,IConfiguration configuration)
        {
            var apiBaseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
            services.AddHttpClient<IDepartmentApiService,DepartmentApiService>("DepartmentAPI", client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });
            
            return services;

        }
        
    }
}