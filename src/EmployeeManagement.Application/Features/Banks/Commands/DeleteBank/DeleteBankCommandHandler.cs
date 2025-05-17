
using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Commands.DeleteBank
{
    public sealed class DeleteBankCommandHandler : IRequestHandler<DeleteBankCommand, ResultT<bool>>
    {
        private readonly IBankWriteRepository _bankWriteRepository;
        private readonly IBankReadRepository _bankReadRepository;
        public DeleteBankCommandHandler(IBankWriteRepository bankWriteRepository, IBankReadRepository bankReadRepository)
        {
            _bankWriteRepository = bankWriteRepository;
            _bankReadRepository = bankReadRepository;
        }

        public async Task<ResultT<bool>> Handle(DeleteBankCommand request, CancellationToken cancellationToken)
        {
            var bankId = new BankId(request.BankId);
            var bank = await _bankReadRepository.GetByIdAsync(bankId, cancellationToken);
            if (bank is null)
            {
                return ResultT<bool>.Failed(Error.NotFound("Bank not found", $"Bank with Id {request.BankId} not found"));
            }

            await _bankWriteRepository.DeleteAsync(bank, cancellationToken);
            return ResultT<bool>.Success(true);
        }
    }
}