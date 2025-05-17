using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee;

    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResultT<EmployeeResponse>>
{
    private readonly IEmployeeWriteRepository _writeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(
        IEmployeeWriteRepository writeRepository,
        IMapper mapper)
    {
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task<ResultT<EmployeeResponse>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(command);
        if (employee.Id is null|| employee.Id.Value == Guid.Empty)
        {
                employee.Id = new EmployeeId(Guid.NewGuid());
        }
        
        await _writeRepository.AddAsync(employee, cancellationToken);
        
        var response = _mapper.Map<EmployeeResponse>(employee);
        
        return ResultT<EmployeeResponse>.Success(
            response);
    }
}
