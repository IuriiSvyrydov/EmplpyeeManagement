using EmployeeManagement.Domain.Entities.Departments;

namespace EmployeeManagement.UI.Dtos;

public class CreateEmployeeDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }

    //relation
    public Guid DepartmentId { get; set; }
    public string Designation { get; set; }
    public string CreateById { get; set; }
    public DateTime CreateOn { get; set; }
    public string ModifiedById { get; set; }
    public DateTime ModifiedOn { get; set; }
}