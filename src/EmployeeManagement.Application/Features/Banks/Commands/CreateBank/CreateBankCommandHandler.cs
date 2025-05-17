using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Commands.CreateBank;

public sealed class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, ResultT<CreateBankResponse>>
{
    private readonly IBankWriteRepository _bankRepository;
    private readonly IMapper _mapper;
    public CreateBankCommandHandler(IBankWriteRepository bankRepository, IMapper mapper)
    {
        _bankRepository = bankRepository ?? throw new ArgumentNullException(nameof(bankRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ResultT<CreateBankResponse>> Handle(CreateBankCommand request, CancellationToken cancellationToken)
    {


        var bank = _mapper.Map<Bank>(request);


        if (bank.BankId is null || bank.BankId.Value == Guid.Empty)
        {
            bank.BankId = BankId.NewId();
        }
        
        await _bankRepository.AddAsync(bank, cancellationToken);
        
        var response = _mapper.Map<CreateBankResponse>(bank);
        
        return ResultT<CreateBankResponse>.Success(response);
    }
}
