using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Departments;

public sealed class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
{
    public DepartmentReadRepository(DbContext context) : base(context)
    {
    }
}