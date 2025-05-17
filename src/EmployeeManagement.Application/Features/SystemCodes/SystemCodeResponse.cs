using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.SystemCodes
{
    public record SystemCodeResponse(Guid SystemCodeId, string Code, string Description);
    
}