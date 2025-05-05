using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;
using EmployeeManagement.Domain.Entities.ValueObjects;

namespace EmployeeManagement.Domain.Entities.Employees;

public sealed class Employee : UserActivity
{
    public EmployeeId Id { get; set; }
    public FirstName FirstName { get; set; }
    public MiddleName MiddleName { get; set; }
    public LastName LastName { get; set; }
    public DateOfBirth DateOfBirth { get; set; }
    public EmailAddress EmailAddress { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public Country Country { get; set; }
    public Address Address { get; set; }
    
    //relation
    
    public Department Department { get; set; }
    public DepartmentId DepartmentId { get; set; }
    public string Designation { get; set; }

    

}
