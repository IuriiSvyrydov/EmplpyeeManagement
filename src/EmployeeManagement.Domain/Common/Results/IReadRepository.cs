

namespace EmployeeManagement.Domain.Common.Results;

public interface IReadRepository<T, TId> where T : class
{
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
