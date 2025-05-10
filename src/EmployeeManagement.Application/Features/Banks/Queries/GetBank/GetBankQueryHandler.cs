using AutoMapper;

using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Queries.GetBank;

public sealed class GetBankQueryHandler : IRequestHandler<GetBankQuery, Result<BankResponse>>
{
    private readonly IBankReadRepository _bankRepository;
    private readonly IMapper _mapper;

    public GetBankQueryHandler(IBankReadRepository bankRepository, IMapper mapper)
    {
        _bankRepository = bankRepository;
        _mapper = mapper;
    }

    public async Task<Result<BankResponse>> Handle(GetBankQuery request, CancellationToken cancellationToken)
    {
        var bank = await _bankRepository.GetByIdAsync(request.Id, cancellationToken);
        var bankResponse = _mapper.Map<BankResponse>(bank);
        return Result<BankResponse>.Success(bankResponse, "Successfully retrieved bank");
    }
}