
using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Application.Messaging;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;

    public record DeleteDepartmentCommand(Guid DepartmentId) : ICommand<bool>, ICommand<ResultT<bool>>;
    
