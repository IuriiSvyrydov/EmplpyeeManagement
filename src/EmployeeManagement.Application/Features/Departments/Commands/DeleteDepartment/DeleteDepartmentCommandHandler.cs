using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using MediatR;

namespace EmployeeManagement.Application.Features.Departments.Commands.DeleteDepartment;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, ResultT<bool>>
{
    private readonly IDepartmentReadRepository _readRepository;
    private readonly IDepartmentWriteRepository _writeRepository;


    public DeleteDepartmentCommandHandler(IDepartmentReadRepository readRepository, IDepartmentWriteRepository writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }


    public async Task<ResultT<bool>> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var departmentId = new DepartmentId(command.DepartmentId);
        var department = await _readRepository.GetByIdAsync(departmentId, cancellationToken);
        if (department is null)
        {
            return ResultT<bool>.Failed(Error.NotFound("Department not found", $"Department with Id {command.DepartmentId} not found"));
        }

        await _writeRepository.DeleteAsync(department, cancellationToken);
        return ResultT<bool>.Success(true);
    }

  
}
