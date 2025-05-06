using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Domain.Entities.Employees;

public interface IEmployeeReadRepository
{
    Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
}