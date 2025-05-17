using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Middlewares
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
         public ErrorDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}