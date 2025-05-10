using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.UI.Models.BaseTypes;

namespace EmployeeManagement.UI.Models.Departments.ValueObjects;

public class DepartmentId : ValueObject<Guid>
{
    public DepartmentId(Guid value) : base(value)
    {
    }
    public static ValidationResult<DepartmentId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add(("EmployeeId cannot be empty"));
        return errors.Count==0? ValidationResult<DepartmentId>.Success(new DepartmentId(value))
            :ValidationResult<DepartmentId>.Failed(errors);
      
    }
    public static DepartmentId NewId()
        =>new DepartmentId(Guid.NewGuid());
}