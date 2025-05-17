using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Features.Banks.Queries.GetBank;

public record GetBankQuery(Guid Id): IRequest<ResultT<BankResponse>>;