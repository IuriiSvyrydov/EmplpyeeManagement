
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;

namespace EmployeeManagement.Persistence.Repositories.Departments
{
    public sealed class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(AppDbContext context,IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
