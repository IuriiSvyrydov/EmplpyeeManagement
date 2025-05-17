using EmployeeManagement.Domain.Common.Results;

using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;

namespace EmployeeManagement.Application.Features.Departments.Commands.UpdateDepartment
{
    public sealed class UpdateDepartmentCommandHandler : ICommandHandler<UpdateDepartmentCommand,DepartmentResponse>
    {
        private readonly IDepartmentReadRepository _readRepository;
        private readonly IDepartmentWriteRepository _writeRepository;
        private readonly IMapper _mapper;
 

        public UpdateDepartmentCommandHandler(
            IDepartmentReadRepository readRepository,
            IDepartmentWriteRepository writeRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        public async Task<ResultT<DepartmentResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentId = new DepartmentId(request.DepartmentId);
            var department = await _readRepository.GetByIdAsync(departmentId, cancellationToken);
            if (department is null)
            {
                return ResultT<DepartmentResponse>.Failed(Error.NotFound("Error not found",$"Department with Id {request.DepartmentId} not found"));
            }
            await _writeRepository.UpdateAsync(department, cancellationToken);
            return ResultT<DepartmentResponse>.Success(_mapper.Map<DepartmentResponse>(department));
        }
    }
}