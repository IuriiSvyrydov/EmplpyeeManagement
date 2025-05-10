
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Persistence.Repositories.Employees;
using Microsoft.Extensions.DependencyInjection;
using EmployeeManagement.Persistence.Repositories;
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Persistence.Repositories.Departments;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Persistence.Repositories.Banks;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
namespace EmployeeManagement.Persistence.Extensions;

public static class RegisterRepositoryExtensions
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        #region Employee Repositories 
        services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
        services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();
        #endregion

        #region Department Repositories
        services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
        services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
        #endregion

        #region Bank Repositories
        services.AddScoped<IBankWriteRepository, BankWriteRepository>();
        services.AddScoped<IBankReadRepository, BankReadRepository>();
        #endregion

        #region Genetic Repositories
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        #endregion

        #region Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion
    }
}