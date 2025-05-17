using EmployeeManagement.Application.Messaging;
using MediatR;

using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments;

public record GetAllDepartmentsQuery(): IRequest<ResultT<List<DepartmentResponse>>>;
    
