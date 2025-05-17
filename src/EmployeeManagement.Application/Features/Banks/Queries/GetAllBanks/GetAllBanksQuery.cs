
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;



namespace EmployeeManagement.Application.Features.Banks.Queries.GetAllBanks;

public record GetAllBanksQuery : IRequest<ResultT<List<BankResponse>>>;
