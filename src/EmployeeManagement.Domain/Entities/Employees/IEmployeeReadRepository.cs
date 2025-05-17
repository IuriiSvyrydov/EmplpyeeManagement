using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;


namespace EmployeeManagement.Domain.Entities.Employees;

public interface IEmployeeReadRepository : IReadRepository<Employee,EmployeeId>
{
}
