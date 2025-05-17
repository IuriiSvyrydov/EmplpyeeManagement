
using EmployeeManagement.Domain.Common.Results;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.GenericRepositories;

public class ReadRepository<T,TId> : IReadRepository<T,TId> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public ReadRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

   

    public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(id , cancellationToken);
    }

    public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }
}


