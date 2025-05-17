

using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;


namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment
{
    public record UpdateDepartmentCommand(Guid DepartmentId) : ICommand<DepartmentResponse>;

}