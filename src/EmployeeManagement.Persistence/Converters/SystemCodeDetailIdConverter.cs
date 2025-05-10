using EmployeeManagement.Domain.Entities.SystemCodeDetails.ValueObject;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

internal class SystemCodeDetailIdConverter: ValueConverter<SystemCodeDetailId, Guid>
{
    public SystemCodeDetailIdConverter() : base(e => e.Value,
        id => SystemCodeDetailId.Create(id).Value)
    {

    }

}

public sealed class SystemCodeDetailIdComparer : ValueComparer<SystemCodeDetailId>
{
    public SystemCodeDetailIdComparer() : base(
        (x, y) => x!.Value == y!.Value,
        x => x.Value.GetHashCode())
    {

    }
}
