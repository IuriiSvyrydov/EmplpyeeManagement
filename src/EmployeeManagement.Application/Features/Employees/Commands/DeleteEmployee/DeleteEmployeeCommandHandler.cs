
using EmployeeManagement.Application.Messaging;
using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;


namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

    public sealed class DeleteEmployeeCommandHandler:IRequestHandler<DeleteEmployeeCommand, ResultT<bool>>
    {
        private readonly IEmployeeReadRepository _readRepository;
        private readonly IEmployeeWriteRepository _writeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeReadRepository readRepository, 
            IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        
        public async Task<ResultT<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeId = new EmployeeId(request.EmployeeId);
            var employee = await _readRepository.GetByIdAsync(employeeId, cancellationToken);
            if (employee is null)
            {
                return ResultT<bool>.Failed(Error.NotFound("Error not found",$"Employee with Id {request.EmployeeId} not found"));
            }
            await _writeRepository.DeleteAsync(employee, cancellationToken);
            return ResultT<bool>.Success( true);
        }
    }
