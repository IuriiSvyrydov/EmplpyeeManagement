using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.Departments.ValueObject;

public class DepartmentId : ValueObject<Guid>
{
    private DepartmentId(Guid value) : base(value)
    {
    }
    public static ValidationResult<DepartmentId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add("DepartmentId cannot be empty");
        return errors.Count == 0 ? ValidationResult<DepartmentId>.Success(new DepartmentId(value))
            : ValidationResult<DepartmentId>.Failed(errors);
    }
    public static DepartmentId NewId()
    {
        return Create(Guid.NewGuid()).Value;
    }
}