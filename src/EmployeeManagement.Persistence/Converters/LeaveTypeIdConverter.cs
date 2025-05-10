using EmployeeManagement.Domain.Entities.LeaveTypes.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

public class LeaveTypeIdConverter : ValueConverter<LeaveTypeId, Guid>
{
    public LeaveTypeIdConverter() : base(e => e.Value,
        id => LeaveTypeId.Create(id).Value)
    {

    }
}


public sealed class LeaveTypeIdComparer : ValueComparer<LeaveTypeId>
{
    public LeaveTypeIdComparer():base(
        (x,y)=>x!.Value==y!.Value,
        x=>x.Value.GetHashCode())
    {
      
    }
}