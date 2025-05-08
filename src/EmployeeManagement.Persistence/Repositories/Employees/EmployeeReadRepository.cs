using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Employees;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly AppDbContext _appDbContext;

    public EmployeeReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
{
    var employeeIdResult = EmployeeId.Create(id);
    var employeeId = employeeIdResult.Value;
    
    return await _appDbContext.Employees
        .Where(e => e.Id == employeeId)
        .FirstOrDefaultAsync(cancellationToken);
}

    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Employees
            .ToListAsync(cancellationToken);
    }
}