
namespace EmployeeManagement.UI.Dtos;

public class EmployeeDto
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
    public string Designation { get; set; }

    //relation

    public Guid DepartmentId { get; set; }
    public string? CreateById { get; set; }
    public DateTime CreateOn { get; set; } = DateTime.Now;
    public string? ModifiedById { get; set; }
    public DateTime ModifiedOn { get; set; } = DateTime.Now;

}