
using EmployeeManagement.Application.Messaging;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public record GetAllEmployeesQuery : IQuery<List<EmployeeResponse>>;
    
}