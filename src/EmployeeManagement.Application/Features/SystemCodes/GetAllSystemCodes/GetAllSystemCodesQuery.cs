using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Application.Features.SystemCodes.GetAllSystemCodes
{
    public record GetAllSystemCodesQuery : IRequest<ResultT<List<SystemCodeResponse>>>;
}