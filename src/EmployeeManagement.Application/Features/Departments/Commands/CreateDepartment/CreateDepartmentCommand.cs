
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;


namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public sealed record CreateDepartmentCommand: IRequest<ResultT<DepartmentResponse>>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    };
    
}