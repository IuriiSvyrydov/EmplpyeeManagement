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
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<T>() ?? throw new InvalidOperationException($"Could not create DbSet for type {typeof(T).Name}");
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null when adding to the database.");

        try 
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            // Log the detailed exception
            throw new InvalidOperationException($"Error adding {typeof(T).Name} to database: {ex.Message}", ex);
        }
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null when updating in the database.");

        _dbSet.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null when deleting from the database.");

        _dbSet.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}