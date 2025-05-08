
using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Persistence.Frameworks.Contexts;

namespace EmployeeManagement.Persistence.Repositories.Departments
{
   public sealed class DepartmentWriteRepository : IDepartmentWriteRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentWriteRepository(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(Department department, CancellationToken cancellationToken)
        {
            await _appDbContext.Departments.AddAsync(department, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(Department department, CancellationToken cancellationToken)
        {
            _appDbContext.Departments.Update(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Department department, CancellationToken cancellationToken)
        {
            _appDbContext.Departments.Remove(department);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
