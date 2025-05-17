using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class SystemCodeIdConverter : ValueConverter<SystemCodeId, Guid>
{
    public SystemCodeIdConverter() : base(
        e => e.Value,
        id => SystemCodeId.Create(id).Value!)
    {
    }
}

public sealed class SystemCodeIdComparer : ValueComparer<SystemCodeId>
{
    public SystemCodeIdComparer() : base(
        (x, y) => x!.Value == y!.Value,
        x => x.Value.GetHashCode())
    {
    }
}