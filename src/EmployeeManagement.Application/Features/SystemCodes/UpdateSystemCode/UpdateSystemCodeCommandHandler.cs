
using MediatR;
using EmployeeManagement.Application.Features.SystemCodes;
using EmployeeManagement.Application.Features.SystemCodes.UpdateSystemCode;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Common.Errors;
using AutoMapper;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Features.SystemCodes.UpdateSystemCode
{
    public sealed class UpdateSystemCodeCommandHandler : IRequestHandler<UpdateSystemCodeCommand, ResultT<SystemCodeResponse>>
    {
        private readonly ISystemCodeWriteRepository _writeRepository;
        private readonly ISystemCodeReadRepository _readRepository;
        private readonly IMapper _mapper;

        public UpdateSystemCodeCommandHandler(ISystemCodeWriteRepository writeRepository, ISystemCodeReadRepository readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<ResultT<SystemCodeResponse>> Handle(UpdateSystemCodeCommand request, CancellationToken cancellationToken)
        {
            var systemCodeId = new SystemCodeId(request.SystemCodeId);
            var systemCode = await _readRepository.GetByIdAsync(systemCodeId, cancellationToken);
            if (systemCode is null)
            {
                return ResultT<SystemCodeResponse>.Failed(
                    Error.NotFound("SystemCode not found", $"SystemCode with Id {request.SystemCodeId} not found"));
            }
            
            systemCode.Code = new Code(request.Code);
            systemCode.Description = new Description(request.Description);
            await _writeRepository.UpdateAsync(systemCode, cancellationToken);
            return ResultT<SystemCodeResponse>.Success(_mapper.Map<SystemCodeResponse>(systemCode));
        }
    }
}