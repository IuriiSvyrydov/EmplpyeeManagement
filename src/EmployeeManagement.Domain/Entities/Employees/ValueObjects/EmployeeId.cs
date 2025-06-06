using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.Employees.ValueObjects;

public sealed class EmployeeId : ValueObject<Guid>
{
    private EmployeeId()
    {
    }
    public EmployeeId(Guid value) : base(value)
    {
    }
    public static ValidationResult<EmployeeId> Create(Guid value)
    {
       var errors = new List<string>();
       if (value == Guid.Empty) errors.Add(("EmployeeId cannot be empty"));
       return errors.Count==0? ValidationResult<EmployeeId>.Success(new EmployeeId(value))
       :ValidationResult<EmployeeId>.Failed(errors);
      
    }
    public static EmployeeId NewId()
    =>new EmployeeId(Guid.NewGuid());
}