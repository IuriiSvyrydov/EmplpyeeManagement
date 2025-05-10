
using AutoMapper;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Commands.CreateBank
{
    public sealed class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, Result<CreateBankResponse>>
    {
        private readonly IBankWriteRepository _bankRepository;
        private readonly IMapper _mapper;
        public CreateBankCommandHandler(IBankWriteRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }
        public async Task<Result<CreateBankResponse>> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = _mapper.Map<Bank>(request);
            await _bankRepository.AddAsync(bank, cancellationToken);
            return Result<CreateBankResponse>.Success(_mapper.Map<CreateBankResponse>(bank), "Bank created successfully");
        }
    }
}