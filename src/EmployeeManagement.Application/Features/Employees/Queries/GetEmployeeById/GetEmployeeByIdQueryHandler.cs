using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using MediatR;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
    private readonly IEmployeeReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeeReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<ResultT<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employeeId = new EmployeeId(request.EmployeeId);
        var employee = await _readRepository.GetByIdAsync(employeeId, cancellationToken);
        return employee is null 
            ? ResultT<EmployeeResponse>.Failed(Error.NotFound("Error not found",$"Employee with Id {request.EmployeeId} not found"))
            : ResultT<EmployeeResponse>.Success(_mapper.Map<EmployeeResponse>(employee));
    }
}