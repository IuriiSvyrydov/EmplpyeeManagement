using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.UI.Dtos.DepartmentsDtos;
using EmployeeManagement.UI.Models;

namespace EmployeeManagement.UI.Services.Departments
{
    public interface IDepartmentApiService
    {
        Task<Result<List<DepartmentDto>>> GetAllDepartmentsAsync();
        Task<Result<DepartmentDto>> GetDepartmentByIdAsync(Guid id);
        Task<Result<DepartmentDto>> CreateDepartmentAsync(CreateDepartmentDto department);
        Task<Result<DepartmentDto>> UpdateDepartmentAsync(Guid id, UpdateDepartmentDto department);
        Task<Result<bool>> DeleteDepartmentAsync(Guid id);

      
    }
}