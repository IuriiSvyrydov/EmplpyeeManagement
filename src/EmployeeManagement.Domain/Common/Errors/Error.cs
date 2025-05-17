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
        public ErrorType Type { get; set; }

        public Error(string code, string message, ErrorType type)
        {
            Code = code;
            Message = message;
            Type = type;
        }
        public static Error Failure(string code,string description)=>new(code,description,ErrorType.Failure);   
        public static Error NotFound(string code,string description)=>new(code,description,ErrorType.NotFound);
        public static Error BadRequest(string code,string description)=>new(code,description,ErrorType.BadRequest);
        public static Error Unauthorized(string code,string description)=>new(code,description,ErrorType.Unauthorized);
        public static Error Validation(string code,string description)=>new(code,description,ErrorType.Validation);
        public static Error Conflict(string code,string description)=>new(code,description,ErrorType.Conflict);
        public static Error Forbidden(string code,string description)=>new(code,description,ErrorType.Forbidden);
        public static Error InternalServerError(string code,string description)=>new(code,description,ErrorType.InternalServerError);
    }
}