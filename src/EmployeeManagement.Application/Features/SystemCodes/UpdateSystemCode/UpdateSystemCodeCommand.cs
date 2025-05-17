using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.SystemCodes;
using MediatR;

namespace EmployeeManagement.Application.Features.SystemCodes.UpdateSystemCode
{
    public class UpdateSystemCodeCommand : IRequest<ResultT<SystemCodeResponse>>
    {
        public Guid SystemCodeId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}