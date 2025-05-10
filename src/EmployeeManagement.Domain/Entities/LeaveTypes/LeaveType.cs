using EmployeeManagement.Domain.Entities.LeaveTypes.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.LeaveTypes;

public sealed class LeaveType : UserActivity
{
    public LeaveTypeId LeaveTypeId { get; set; }
    public Code Code { get; set; }
    public Name Name { get; set; }
    
}