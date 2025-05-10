

using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.Banks.ValueObject;

public class BankId: ValueObject<Guid>
{
    public BankId(Guid value) : base(value)
    {
    }
    public static ValidationResult<BankId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add("DepartmentId cannot be empty");
        return errors.Count == 0 ? ValidationResult<BankId>.Success(new BankId(value))
            : ValidationResult<BankId>.Failed(errors);
    }
    public static BankId NewId()
    {
        return Create(Guid.NewGuid()).Value;
    }
}
