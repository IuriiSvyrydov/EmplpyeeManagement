using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Application.Features.Employees;


namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public record GetAllEmployeesQuery : IRequest<Result<List<EmployeeResponse>>>;
    
}