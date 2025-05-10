using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

public class DepartmentIdConverter : ValueConverter<DepartmentId,Guid>
{
    public DepartmentIdConverter() : base(e => e.Value,
        id => DepartmentId.Create(id).Value)
    {

    }
    
}
public sealed class DepartmentIdComparer : ValueComparer<DepartmentId>
{
    public DepartmentIdComparer():base(
        (x,y)=>x!.Value==y!.Value,
        x=>x.Value.GetHashCode())
    {
      
    }
}