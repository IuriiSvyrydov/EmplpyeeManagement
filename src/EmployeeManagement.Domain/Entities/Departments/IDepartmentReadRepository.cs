using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;

namespace EmployeeManagement.Domain.Entities.Departments
{
    public interface IDepartmentReadRepository : IReadRepository<Department,DepartmentId>
    {
      

    }
}
