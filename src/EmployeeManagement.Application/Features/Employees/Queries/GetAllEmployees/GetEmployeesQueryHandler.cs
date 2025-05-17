
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Common.Errors;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Application.Features.Employees.Queries.GetAllEmployees
{
     public sealed class GetEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeeReadRepository _readRepository;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IEmployeeReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<ResultT<List<EmployeeResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _readRepository.GetAllAsync(cancellationToken);

            if (employees == null || !employees.Any())
            {
                return ResultT<List<EmployeeResponse>>.Failed(Error.NotFound("List of employees not found", "List of employees not found"));
            }
            
            return ResultT<List<EmployeeResponse>>.Success( _mapper.Map<List<EmployeeResponse>>(employees));
        }
    }
}