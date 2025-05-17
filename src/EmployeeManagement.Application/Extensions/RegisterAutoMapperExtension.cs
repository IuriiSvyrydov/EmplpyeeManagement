using System.Reflection;
using EmployeeManagement.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
namespace EmployeeManagement.Application.Extensions;

    public static class RegisterAutoMapperExtension
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(DepartmentMappingProfile).Assembly);
            services.AddAutoMapper(typeof(BankMapper).Assembly);
            services.AddAutoMapper(typeof(EmployeeMapper).Assembly);


            return services;
        }
    }
