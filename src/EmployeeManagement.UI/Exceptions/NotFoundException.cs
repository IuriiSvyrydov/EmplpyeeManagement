﻿namespace EmployeeManagement.UI.Exceptions;

public class NotFoundException : Exception
{
    public string Message { get; set; }
    public NotFoundException()
    {
    }
    public NotFoundException(string message)
    {
        Message = message;
    }
    
}