using MediatR;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Application.Features.SystemCodes.DeleteSystemCode
{
    public sealed record DeleteSystemCodeCommand(Guid SystemCodeId): IRequest<ResultT<bool>>;
}