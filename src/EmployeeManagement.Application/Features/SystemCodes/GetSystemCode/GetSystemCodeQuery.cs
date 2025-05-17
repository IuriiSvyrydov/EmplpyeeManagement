
using MediatR;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Application.Features.SystemCodes.GetSystemCode
{
    public record GetSystemCodeQuery(Guid SystemCodeId) : IRequest<ResultT<SystemCodeResponse>>;
}