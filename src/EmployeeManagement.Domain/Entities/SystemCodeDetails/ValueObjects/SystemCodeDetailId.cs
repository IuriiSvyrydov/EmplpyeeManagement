using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.SystemCodeDetails.ValueObject
{
    public class SystemCodeDetailId:ValueObject<Guid>
    {
        public SystemCodeDetailId(Guid value):base(value)
        {
        }

        public static ValidationResult<SystemCodeDetailId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add("SystemCodeDetailId cannot be empty");
        return errors.Count == 0 ? ValidationResult<SystemCodeDetailId>.Success(new SystemCodeDetailId(value))
            : ValidationResult<SystemCodeDetailId>.Failed(errors);
    }
    public static SystemCodeDetailId NewId()
    {
        return Create(Guid.NewGuid()).Value;
    }
    }
}