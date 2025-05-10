using MediatR;
using AutoMapper;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Common.Errors;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Result<EmployeeResponse>>
    {
        private readonly IEmployeeReadRepository _readRepository;
        private readonly IEmployeeWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        
        public UpdateEmployeeCommandHandler(
            IEmployeeReadRepository readRepository, 
            IEmployeeWriteRepository writeRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        
        public async Task<Result<EmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _readRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
            if (employee is null)
            {
                return Result<EmployeeResponse>.Failure(
                    Error.NotFound("Employee not found", $"Employee with Id {request.EmployeeId} not found"));
            }

            _mapper.Map(request, employee);
            await _writeRepository.UpdateAsync(employee, cancellationToken);
            
            return Result<EmployeeResponse>.Success(
                _mapper.Map<EmployeeResponse>(employee), 
                "Employee updated successfully");
        }
    }
}