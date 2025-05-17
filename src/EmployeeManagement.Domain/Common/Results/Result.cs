using System.Text.Json.Serialization;
using EmployeeManagement.Domain.Common.Errors;

namespace EmployeeManagement.Domain.Common.Results;

    public class Result
    {
        protected Result()
        {
            IsSuccess = true;
            Error = default;
        }
        protected Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }
        public bool IsSuccess { get; }
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Error? Error { get; }
        public static implicit operator Result(Error error)=>new(error);
        public static Result Success()=>new();
        public static Result Failed(Error error)=>new(error);

    }
    public class ResultT<T>:Result
    {
        private readonly T _value;
        protected ResultT(T value)
        {
            _value = value;
        }
        protected ResultT(Error error):base(error)
        {
            _value=default!;
        }
        
        public T Value=> IsSuccess ? _value : throw new InvalidOperationException("Result is not a success");
        public static implicit operator ResultT<T>(Error error)=>new(error);
        public static implicit operator ResultT<T>(T value) => new(value);
        public static ResultT<T> Success(T value)=>new(value);
        public static ResultT<T> Failed(Error error)=>new(error);
        


    }
