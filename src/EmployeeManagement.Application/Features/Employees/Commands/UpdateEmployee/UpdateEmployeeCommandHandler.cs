using MediatR;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Application.Features.Employees.Commands.UpdateEmployee
{
    public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResultT<EmployeeResponse>>
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
        
        public async Task<ResultT<EmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(request.EmployeeId);
            var employee = await _readRepository.GetByIdAsync(employeeId, cancellationToken);
            if (employee is null)
            {
                return ResultT<EmployeeResponse>.Failed(
                    Error.NotFound("Employee not found", $"Employee with Id {request.EmployeeId} not found"));
            }

            _mapper.Map(request, employee);
            await _writeRepository.UpdateAsync(employee, cancellationToken);
            return ResultT<EmployeeResponse>.Success(_mapper.Map<EmployeeResponse>(employee));
        }
    }
}