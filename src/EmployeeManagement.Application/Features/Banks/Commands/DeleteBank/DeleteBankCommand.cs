using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Commands.DeleteBank
{
    public record DeleteBankCommand(Guid BankId) : IRequest<ResultT<bool>>;

}