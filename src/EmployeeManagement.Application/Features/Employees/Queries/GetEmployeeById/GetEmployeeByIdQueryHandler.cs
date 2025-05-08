using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using MediatR;
using AutoMapper;
using EmployeeManagement.Domain.Common.Errors;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetEmployeeById;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeResponse>>
{
    private readonly IEmployeeReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeeReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<Result<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _readRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        return employee is null 
            ? Result<EmployeeResponse>.Failure(Error.NotFound("Error not found",$"Employee with Id {request.EmployeeId} not found"))
            : Result<EmployeeResponse>.Success(_mapper.Map<EmployeeResponse>(employee), "Successfully retrieved employee");
    }
}