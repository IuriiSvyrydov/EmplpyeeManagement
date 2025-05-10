
using System.Diagnostics.Contracts;
using EmployeeManagement.UI.Models.Departments.ValueObjects;

namespace EmployeeManagement.UI.Models.Departments
{
    public class Department
    {
        public DepartmentId Id { get; set; }
        public Code Code { get; set; }
        public Name  Name { get; set; }
    }
}