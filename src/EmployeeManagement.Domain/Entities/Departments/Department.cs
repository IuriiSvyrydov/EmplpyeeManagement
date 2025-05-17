using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Domain.Entities.Departments;

public sealed class Department
{
   
    public DepartmentId DepartmentId { get; set; }
    public Code Code { get; set; }
    public Name  Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}