using MediatR;

using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using AutoMapper;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Features.SystemCodes.CreateSystemCode
{
    public class CreateSystemCodeCommandHandler : IRequestHandler<CreateSystemCodeCommand, ResultT<SystemCodeResponse>>
    {
        private readonly ISystemCodeWriteRepository _systemCodeWriteRepository;
        private readonly IMapper _mapper;
        
        public CreateSystemCodeCommandHandler(ISystemCodeWriteRepository systemCodeWriteRepository, IMapper mapper)
        {
            _systemCodeWriteRepository = systemCodeWriteRepository;
            _mapper = mapper;
        }

        public async Task<ResultT<SystemCodeResponse>> Handle(CreateSystemCodeCommand request, CancellationToken cancellationToken)
        {
            var systemCode = _mapper.Map<SystemCode>(request);
            if (systemCode.SystemCodeId is null || systemCode.SystemCodeId.Value == Guid.Empty)
            {
                systemCode.SystemCodeId = SystemCodeId.NewId();
            }
            await _systemCodeWriteRepository.AddAsync(systemCode, cancellationToken);
            return ResultT<SystemCodeResponse>.Success(_mapper.Map<SystemCodeResponse>(systemCode));
        }
    }
}