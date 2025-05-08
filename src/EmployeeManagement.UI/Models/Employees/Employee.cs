using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.ValueObjects;
using EmployeeManagement.UI.Models.Employees.ValueObjects;
using MiddleName = EmployeeManagement.Domain.Entities.ValueObjects.MiddleName;

namespace EmployeeManagement.UI.Models.Employees
{
    public  class Employee
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
}
