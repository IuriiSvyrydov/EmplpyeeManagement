using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Persistence.Frameworks.Contexts;

namespace EmployeeManagement.Persistence.Repositories.Employees;

public sealed class EmployeeWriteRepository: IEmployeeWriteRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IUnitOfWork _unitOfWork;

    public EmployeeWriteRepository(AppDbContext appDbContext, IUnitOfWork unitOfWork)
    {
        _appDbContext = appDbContext;
        _unitOfWork = unitOfWork;
    }
    

    public async Task AddAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Employees.AddAsync(employee, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        _appDbContext.Employees.Update(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        _appDbContext.Employees.Remove(employee);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}