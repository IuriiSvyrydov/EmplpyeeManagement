using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.Departments
{
    public interface IDepartmentWriteRepository
    {
        Task AddAsync(Department department, CancellationToken cancellationToken);
        Task UpdateAsync(Department department, CancellationToken cancellationToken);
        Task DeleteAsync(Department department, CancellationToken cancellationToken);
    }
}