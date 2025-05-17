using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using EmployeeManagement.Persistence.Frameworks.Contexts;


namespace EmployeeManagement.Persistence.Repositories.SystemCodes
{
    public sealed class SystemCodeWriteRepository : WriteRepository<SystemCode>, ISystemCodeWriteRepository
    {
        public SystemCodeWriteRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}