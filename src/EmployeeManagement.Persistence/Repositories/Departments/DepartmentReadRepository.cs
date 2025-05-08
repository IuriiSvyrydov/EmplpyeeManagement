using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Departments;

public sealed class DepartmentReadRepository : IDepartmentReadRepository
{
    private readonly AppDbContext _appDbContext;
    public DepartmentReadRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Department>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext.Departments.ToListAsync(cancellationToken);
    }

    public async Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var departmentIdResult = DepartmentId.Create(id);
        var departmentId = departmentIdResult.Value;
        
        return await _appDbContext.Departments
            .FirstOrDefaultAsync(x => x.DepartmentId == departmentId, cancellationToken);
    }

    public async Task<Department?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var nameResult = new Name(name);
        var departmentName = nameResult.Value;
        
        return await _appDbContext.Departments
            .FirstOrDefaultAsync(x => x.Name.Value == departmentName, cancellationToken);
    }
}