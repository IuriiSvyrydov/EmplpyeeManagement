using MediatR;
using EmployeeManagement.Domain.Common.Results;

using AutoMapper;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees
{
    public sealed class GetEmployeesQueryHandler: IRequestHandler<GetAllEmployeesQuery, Result<List<EmployeeResponse>>>
    {
        private readonly IEmployeeReadRepository _readRepository;
        private readonly IMapper _mapper;
        public GetEmployeesQueryHandler(IEmployeeReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<EmployeeResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _readRepository.GetAllAsync(cancellationToken);
            return Result<List<EmployeeResponse>>.Success(_mapper.Map<List<EmployeeResponse>>(employees), "Successfully retrieved employees");
        }
        
    }
}