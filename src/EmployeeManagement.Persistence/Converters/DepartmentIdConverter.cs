using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class DepartmentIdConverter : ValueConverter<DepartmentId, Guid>
{
    public DepartmentIdConverter() : base(
        e => e.Value,
        id => DepartmentId.Create(id).Value)
    {
    }
}

public sealed class DepartmentIdComparer : ValueComparer<DepartmentId>
{
    public DepartmentIdComparer() : base(
        (x, y) => x!.Value == y!.Value,
        x => x.Value.GetHashCode())
    {
    }
}