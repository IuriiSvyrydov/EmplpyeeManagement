
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetDepartment;

public class GetDepartmentQueryHandler : IQueryHandler<GetDepartmentQuery, DepartmentResponse>
{
    private readonly IDepartmentReadRepository _readRepository;
    private readonly IMapper _mapper;

    public GetDepartmentQueryHandler(IDepartmentReadRepository readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<ResultT<DepartmentResponse>> Handle(GetDepartmentQuery command, CancellationToken cancellationToken)
    {
        var departmentId = new DepartmentId(command.DepartmentId);
        var department = await _readRepository.GetByIdAsync(departmentId, cancellationToken);
        if (department == null)
        {
            return ResultT<DepartmentResponse>.Failed(Error.NotFound("Error not found",$"Department with Id {command.DepartmentId} not found"));
        }
        return ResultT<DepartmentResponse>.Success(_mapper.Map<DepartmentResponse>(department));
    }
}

 