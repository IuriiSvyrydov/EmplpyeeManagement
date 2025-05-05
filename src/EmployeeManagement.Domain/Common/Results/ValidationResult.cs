using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Common.Results
{
    public class ValidationResult<T>
    {
        public T? Value { get; }
        public bool IsValid { get; }
        public List<string> Errors { get; } = new();
        
        public ValidationResult(bool isValid,List<string>errors,T value)
        {
           IsValid = isValid;
           Errors=errors?? new List<string>();
           Value = value;
        }
        public static ValidationResult<T> Success(T value)
        =>new(true,new List<string>(),value);
        public static ValidationResult<T> Failed(List<string> errors)
        =>new(false,errors,default);
        public override string ToString()
        =>IsValid ? $"Valid {Value}" : $"Invalid {Value} {string.Join(",",Errors)}";
    }
}