using EmployeeManagement.UI.Dtos;
using EmployeeManagement.UI.Models;

namespace EmployeeManagement.UI.Services.Employees;

public interface IEmployeeApiService
{
    Task<Result<List<EmployeeDto>>> GetAllEmployeesAsync();
    Task<Result<EmployeeDto>> GetEmployeeByIdAsync(Guid id);
    Task<Result<EmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto employee);
    Task<Result<EmployeeDto>> UpdateEmployeeAsync(Guid id, UpdateEmployeeDto employee);
    Task<Result<bool>> DeleteEmployeeAsync(Guid id);


}