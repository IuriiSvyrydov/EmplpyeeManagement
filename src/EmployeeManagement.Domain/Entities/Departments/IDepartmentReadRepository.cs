using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.Departments
{
    public interface IDepartmentReadRepository
    {
        Task<List<Department>> GetAllAsync(CancellationToken cancellationToken);
        Task<Department?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Department?> GetByNameAsync(string name, CancellationToken cancellationToken);
     

    }
}
