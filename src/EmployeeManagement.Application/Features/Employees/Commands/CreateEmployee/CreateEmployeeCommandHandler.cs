using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Employees;
using AutoMapper;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public sealed class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, Result<EmployeeResponse>>
    {
        private readonly IEmployeeWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        public CreateEmployeeCommandHandler(IEmployeeWriteRepository writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<Result<EmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request);
            employee.Id = EmployeeId.NewId(); // Set the ID before saving
            await _writeRepository.AddAsync(employee, cancellationToken);
            return Result<EmployeeResponse>.Success(_mapper.Map<EmployeeResponse>(employee), "Employee created successfully");
        }
    }
}