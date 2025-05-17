using System.Runtime.InteropServices.JavaScript;
using EmployeeManagement.Domain.Common.Errors;
using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Features.SystemCodes.DeleteSystemCode
{
    public sealed class DeleteSystemCodeCommandHandler: IRequestHandler<DeleteSystemCodeCommand, ResultT<bool>>
    {
        private readonly ISystemCodeWriteRepository _systemCodeWriteRepository;
        private readonly ISystemCodeReadRepository _systemCodeReadRepository;
        public DeleteSystemCodeCommandHandler(ISystemCodeWriteRepository systemCodeWriteRepository)
        {
            _systemCodeWriteRepository = systemCodeWriteRepository;
        }
        public async Task<ResultT<bool>> Handle(DeleteSystemCodeCommand request, CancellationToken cancellationToken)
        {
            var systemCodeId = new SystemCodeId(request.SystemCodeId);
            var systemCode = await _systemCodeReadRepository.GetByIdAsync(systemCodeId, cancellationToken);
            if (systemCode is null)
            {
                return ResultT<bool>.Failed(Error.NotFound("SystemCode not found", $"SystemCode with Id {request.SystemCodeId} not found"));
            }
            await _systemCodeWriteRepository.DeleteAsync(systemCode, cancellationToken);
            return ResultT<bool>.Success(true);
        }
    }
}