
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Domain.Entities.Employees
{
    public interface IEmployeeWriteRepository
    {
       
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task DeleteAsync(Employee employee, CancellationToken cancellationToken = default);
    }
}