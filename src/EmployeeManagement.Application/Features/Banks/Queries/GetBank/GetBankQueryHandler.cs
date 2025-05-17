using AutoMapper;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using MediatR;


namespace EmployeeManagement.Application.Features.Banks.Queries.GetBank;

public sealed class GetBankQueryHandler : IRequestHandler<GetBankQuery, ResultT<BankResponse>>
{
    private readonly IBankReadRepository _bankRepository;
    private readonly IMapper _mapper;

    public GetBankQueryHandler(IBankReadRepository bankRepository, IMapper mapper)
    {
        _bankRepository = bankRepository;
        _mapper = mapper;
    }


    public async Task<ResultT<BankResponse>> Handle(GetBankQuery request, CancellationToken cancellationToken)
    {
        var bankId = new BankId(request.Id);
        var bank = await _bankRepository.GetByIdAsync(bankId, cancellationToken);
        if (bank == null)
        {
            return ResultT<BankResponse>.Failed(Error.NotFound("Bank not found", $"Bank with Id {request.Id} not found"));
        }

        return ResultT<BankResponse>.Success(_mapper.Map<BankResponse>(bank));
    }
}
   