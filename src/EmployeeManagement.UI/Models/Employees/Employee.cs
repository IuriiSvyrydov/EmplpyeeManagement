

using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.UI.Models.Departments;
using EmployeeManagement.UI.Models.Departments.ValueObjects;
using EmployeeManagement.UI.Models.UserActivities;
using Address = EmployeeManagement.UI.Models.Employees.ValueObjects.Address;
using Country = EmployeeManagement.UI.Models.Employees.ValueObjects.Country;
using DateOfBirth = EmployeeManagement.UI.Models.Employees.ValueObjects.DateOfBirth;
using EmailAddress = EmployeeManagement.UI.Models.Employees.ValueObjects.EmailAddress;
using EmployeeId = EmployeeManagement.UI.Models.Employees.ValueObjects.EmployeeId;
using MiddleName = EmployeeManagement.UI.Models.Employees.ValueObjects.MiddleName;
using PhoneNumber = EmployeeManagement.UI.Models.Employees.ValueObjects.PhoneNumber;

namespace EmployeeManagement.UI.Models.Employees
{
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
}
