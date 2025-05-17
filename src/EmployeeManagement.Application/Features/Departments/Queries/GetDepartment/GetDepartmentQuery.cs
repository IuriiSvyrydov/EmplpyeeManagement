
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;


namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartment
{
    public record GetDepartmentQuery(Guid DepartmentId): IQuery<DepartmentResponse>;
}