
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Departments;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public sealed class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, ResultT<DepartmentResponse>>
    {
        private readonly IDepartmentWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        public CreateDepartmentCommandHandler(IDepartmentWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<ResultT<DepartmentResponse>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
           var department = _mapper.Map<Department>(command);
           if (department.DepartmentId is null || department.DepartmentId.Value == Guid.Empty)
           {
               department.DepartmentId = new DepartmentId(Guid.NewGuid());
               
           }
           await _writeRepository.AddAsync(department, cancellationToken);
           return ResultT<DepartmentResponse>.Success(_mapper.Map<DepartmentResponse>(department));
          
        }
    }
}