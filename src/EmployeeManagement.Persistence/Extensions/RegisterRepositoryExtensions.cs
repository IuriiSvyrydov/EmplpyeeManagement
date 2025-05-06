
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Persistence.Repositories.Employees;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Persistence.Repositories;
using EmployeeManagement.Domain.Common;

namespace EmployeeManagement.Persistence.Extensions;

public static class RegisterRepositoryExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
        services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}