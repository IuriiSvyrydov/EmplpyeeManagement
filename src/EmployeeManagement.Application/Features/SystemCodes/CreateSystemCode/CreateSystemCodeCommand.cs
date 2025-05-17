using MediatR;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;

namespace EmployeeManagement.Application.Features.SystemCodes.CreateSystemCode
{
    public record CreateSystemCodeCommand(
        string Code,
        string Description
    ) : IRequest<ResultT<SystemCodeResponse>>;
}