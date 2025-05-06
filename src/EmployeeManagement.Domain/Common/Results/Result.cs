using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Common.Errors;

namespace EmployeeManagement.Domain.Common.Results
{
    public class Result<T>
    {
        public T? Value { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public Result(T value)
        {
            IsSuccess = true;
            Value = value;
            Error = Error.None;
        }
        public Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }
        public static Result<T> Success(T value, string successfullyRetrievedEmployee) => new(value);
        public static Result<T> Failure(Error error) => new(error);
    }
}