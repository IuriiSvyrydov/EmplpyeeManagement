
using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.Designations.ValueObjects
{
    public class DesignationId : ValueObject<Guid>
    {
          public DesignationId(Guid value) : base(value)
    {
    }
    public static ValidationResult<DesignationId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add("DesignationId cannot be empty");
        return errors.Count == 0 ? ValidationResult<DesignationId>.Success(new DesignationId(value))
            : ValidationResult<DesignationId>.Failed(errors);
    }
    public static DesignationId NewId()
    {
        return Create(Guid.NewGuid()).Value;
    }
        
    }
}