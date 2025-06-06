
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Queries.GetAllBanks
{
    public sealed class GetAllBanksQueryHandler: IRequestHandler<GetAllBanksQuery,ResultT<List<BankResponse>>>
    {
        private readonly IBankReadRepository _bankRepository;
        private readonly IMapper _mapper;

        public GetAllBanksQueryHandler(IBankReadRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public async Task<ResultT<List<BankResponse>>> Handle(GetAllBanksQuery request, CancellationToken cancellationToken)
        {
            var banks = await _bankRepository.GetAllAsync(cancellationToken);
            var bankResponses = _mapper.Map<List<BankResponse>>(banks);
            return ResultT<List<BankResponse>>.Success(bankResponses);
        }
    }
}