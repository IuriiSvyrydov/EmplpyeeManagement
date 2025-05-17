using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Employees;

public sealed class EmployeeWriteRepository: WriteRepository<Employee>, IEmployeeWriteRepository
{
    public EmployeeWriteRepository(AppDbContext context,IUnitOfWork unitOfWork) : base(context, unitOfWork)
    {
    }

    
}