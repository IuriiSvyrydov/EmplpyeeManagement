using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Commands.UpdateBank
{
    public record UpdateBankCommand : ICommand<BankResponse>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name {get;set;}
        public string AccountNo { get; set; }
    }
       
}