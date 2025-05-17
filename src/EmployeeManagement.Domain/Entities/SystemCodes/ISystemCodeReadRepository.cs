using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Domain.Entities.SystemCodes;

public interface ISystemCodeReadRepository : IReadRepository<SystemCode,SystemCodeId>;
