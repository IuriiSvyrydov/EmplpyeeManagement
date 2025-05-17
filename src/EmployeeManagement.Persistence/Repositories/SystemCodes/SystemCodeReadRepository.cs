using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using EmployeeManagement.Persistence.Frameworks.Contexts;

namespace EmployeeManagement.Persistence.Repositories.SystemCodes;

public sealed class SystemCodeReadRepository: ReadRepository<SystemCode,SystemCodeId>,ISystemCodeReadRepository
{
    public SystemCodeReadRepository(AppDbContext context) : base(context)
    {
    }
}