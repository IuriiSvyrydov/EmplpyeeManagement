using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;


namespace EmployeeManagement.Application.Features.Banks.Commands.CreateBank;

    public record CreateBankCommand(
        string Code,
        string Name,
        string AccountNo) : IRequest<ResultT<CreateBankResponse>>;
