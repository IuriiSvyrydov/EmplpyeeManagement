using EmployeeManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.GenericRepositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;
    protected readonly IUnitOfWork _unitOfWork;

    public WriteRepository(DbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _unitOfWork = unitOfWork;
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}