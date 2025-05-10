using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.LeaveTypes.ValueObjects;

public class LeaveTypeId :ValueObject<Guid>
{
    public LeaveTypeId(Guid value) : base(value)
    {
    }
    public static ValidationResult<LeaveTypeId> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add(("EmployeeId cannot be empty"));
        return errors.Count==0? ValidationResult<LeaveTypeId>.Success(new LeaveTypeId(value))
            :ValidationResult<LeaveTypeId>.Failed(errors);
      
    }
    public static LeaveTypeId NewId()
        =>new LeaveTypeId(Guid.NewGuid());
}