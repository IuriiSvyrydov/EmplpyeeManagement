
using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Common.Errors;


namespace EmployeeManagement.Application.Features.Employees.Commands.DeleteEmployee;

    public sealed class DeleteEmployeeCommandHandler:IRequestHandler<DeleteEmployeeCommand, Result<bool>>
    {
        private readonly IEmployeeReadRepository _readRepository;
        private readonly IEmployeeWriteRepository _writeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeReadRepository readRepository, 
            IEmployeeWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        
        public async Task<Result<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _readRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
            if (employee is null)
            {
                return Result<bool>.Failure(Error.NotFound("Error not found",$"Employee with Id {request.EmployeeId} not found"));
            }
            await _writeRepository.DeleteAsync(employee, cancellationToken);
            return Result<bool>.Success(true, "Employee deleted successfully");
        }
    }
