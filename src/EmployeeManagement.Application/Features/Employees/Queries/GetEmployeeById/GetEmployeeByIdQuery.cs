
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(Guid EmployeeId): IRequest<Result<EmployeeResponse>>;

