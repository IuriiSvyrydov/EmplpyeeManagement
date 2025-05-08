namespace EmployeeManagement.UI.Models;

public class Result<T>
{
    public Result() { } // Добавляем конструктор без параметров

    public Result(T value, bool isSuccess, bool isFailure, Error error)
    {
        Value = value;
        IsSuccess = isSuccess;
        IsFailure = isFailure;
        Error = error;
    }

    public T Value { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFailure { get; set; }
    public Error Error { get; set; }
}

public class Error
{
    public Error() { } // Добавляем конструктор без параметров

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }
    public string Message { get; set; }
}