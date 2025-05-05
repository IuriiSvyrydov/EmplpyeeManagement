using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Common.Errors
{
    public sealed class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public static Error None = new Error(string.Empty, string.Empty);
        public static Error NotFound(string code, string message)
            =>new(code, message);
        public static Error BadRequest(string code, string message)
            =>new(code, message);
        public static Error Unauthorized(string code, string message)
            =>new(code, message);
        public static Error Validation(string code, string message)
            =>new(code, message);
    }
}