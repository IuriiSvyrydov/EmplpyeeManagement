
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Departments;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Queries.GetAllDepartments
{
    public sealed class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentsQuery, ResultT<List<DepartmentResponse>>>       
        {
        private readonly IDepartmentReadRepository _departmentRepository;
        private readonly IMapper _mapper;
        
        public GetAllDepartmentQueryHandler(IDepartmentReadRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        
        public async Task<ResultT<List<DepartmentResponse>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync(cancellationToken);
            return ResultT<List<DepartmentResponse>>.Success(_mapper.Map<List<DepartmentResponse>>(departments));
        }
    }
}