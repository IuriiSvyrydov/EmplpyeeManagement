using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee;

public record UpdateEmployeeCommand(
    Guid EmployeeId,
    string FirstName,
    string MiddleName,
    string LastName,
    DateTime DateOfBirth,
    string EmailAddress,
    string PhoneNumber,
    string Country,
    string Address,
    string Designation,
    Guid DepartmentId
) : IRequest<Result<EmployeeResponse>>;
