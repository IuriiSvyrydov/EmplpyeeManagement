

using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;


namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<ResultT<bool>>
{
}
