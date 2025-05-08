using System.Linq.Expressions;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

public sealed class EmployeeIdConverter: ValueConverter<EmployeeId, Guid>
{
   public EmployeeIdConverter() : base(e => e.Value,
      id => EmployeeId.Create(id).Value)
   {

   }
   
}

public sealed class EmployeeIdComparer : ValueComparer<EmployeeId>
{
   public EmployeeIdComparer():base(
      (x,y)=>x!.Value==y!.Value,
      x=>x.Value.GetHashCode())
   {
      
   }
}