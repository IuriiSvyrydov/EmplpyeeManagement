
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Domain.Common.Results;

public interface IReadRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
