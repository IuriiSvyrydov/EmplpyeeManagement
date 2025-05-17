using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;

public class SystemCodeId : ValueObject<Guid>
{
    private SystemCodeId()  { }
    public SystemCodeId(Guid value) : base(value)
    {
    }

    public static ValidationResult<SystemCodeId?> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add("SystemCodeId cannot be empty");
        return errors.Count == 0
            ? ValidationResult<SystemCodeId>.Success(new SystemCodeId(value))
            : ValidationResult<SystemCodeId>.Failed(errors);
    }

    public static SystemCodeId? NewId()
    {
        return Create(Guid.NewGuid()).Value;
    }
}