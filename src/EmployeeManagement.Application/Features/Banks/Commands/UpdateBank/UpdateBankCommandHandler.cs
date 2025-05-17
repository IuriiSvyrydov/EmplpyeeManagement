using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using AutoMapper;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;

namespace EmployeeManagement.Application.Features.Banks.Commands.UpdateBank;

    public sealed class UpdateBankCommandHandler : ICommandHandler<UpdateBankCommand, BankResponse>
    {
        private readonly IBankReadRepository _readRepository;
        private readonly IBankWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        
        public UpdateBankCommandHandler(
            IBankReadRepository readRepository, 
            IBankWriteRepository writeRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }


        public async Task<ResultT<BankResponse>> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var bankId = new BankId(request.Id);
            var bank = await _readRepository.GetByIdAsync(bankId, cancellationToken);
            if (bank is null)
            {
                return ResultT<BankResponse>.Failed(
                    Error.NotFound("Bank not found", $"Bank with Id {request.Id} not found"));
            }

            _mapper.Map(request, bank);
            await _writeRepository.UpdateAsync(bank, cancellationToken);
            
            return ResultT<BankResponse>.Success(_mapper.Map<BankResponse>(bank));
        }
    }
