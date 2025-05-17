using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Employees;

public class EmployeeReadRepository : ReadRepository<Employee,EmployeeId>, IEmployeeReadRepository
{

   
    public EmployeeReadRepository(AppDbContext context) : base(context)
    {
        
    }
}