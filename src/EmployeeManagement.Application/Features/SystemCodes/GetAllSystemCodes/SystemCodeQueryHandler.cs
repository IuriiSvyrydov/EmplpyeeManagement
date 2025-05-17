using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Common.Errors;
using AutoMapper;

namespace EmployeeManagement.Application.Features.SystemCodes.GetAllSystemCodes
{
    public sealed class SystemCodeQueryHandler : IRequestHandler<GetAllSystemCodesQuery, ResultT<List<SystemCodeResponse>>>
    {
        private readonly ISystemCodeReadRepository _readRepository;
        private readonly IMapper _mapper;
        
        public SystemCodeQueryHandler(
            ISystemCodeReadRepository readRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        
        public async Task<ResultT<List<SystemCodeResponse>>> Handle(GetAllSystemCodesQuery request, CancellationToken cancellationToken)
        {
            var systemCodes = await _readRepository.GetAllAsync(cancellationToken);
            return ResultT<List<SystemCodeResponse>>.Success(_mapper.Map<List<SystemCodeResponse>>(systemCodes));
        }
    }
}