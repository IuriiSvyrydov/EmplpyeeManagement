
using EmployeeManagement.Application.Messaging;


namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public record GetEmployeeByIdQuery(Guid EmployeeId): IQuery<EmployeeResponse>;

