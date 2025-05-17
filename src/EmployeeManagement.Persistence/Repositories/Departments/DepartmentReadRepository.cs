using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Departments;

public sealed class DepartmentReadRepository : ReadRepository<Department,DepartmentId>, IDepartmentReadRepository
{
    public DepartmentReadRepository(AppDbContext context) : base(context)
    {
    }
}