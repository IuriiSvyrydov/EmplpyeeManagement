using MediatR;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Common.Errors;
using AutoMapper;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

namespace EmployeeManagement.Application.Features.SystemCodes.GetSystemCode
{
    public sealed class GetSystemCodeQueryHandler : IRequestHandler<GetSystemCodeQuery, ResultT<SystemCodeResponse>>
    {
        private readonly ISystemCodeReadRepository _readRepository;
        private readonly IMapper _mapper;
        
        public GetSystemCodeQueryHandler(
            ISystemCodeReadRepository readRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        
        public async Task<ResultT<SystemCodeResponse>> Handle(GetSystemCodeQuery request, CancellationToken cancellationToken)
        {
            var systemCodeId = new SystemCodeId(request.SystemCodeId);
            var systemCode = await _readRepository.GetByIdAsync(systemCodeId, cancellationToken);
            if (systemCode is null)
            {
                return ResultT<SystemCodeResponse>.Failed(
                    Error.NotFound("SystemCode not found", $"SystemCode with Id {request.SystemCodeId} not found"));
            }
            
            return ResultT<SystemCodeResponse>.Success(_mapper.Map<SystemCodeResponse>(systemCode));
        }
    }
}