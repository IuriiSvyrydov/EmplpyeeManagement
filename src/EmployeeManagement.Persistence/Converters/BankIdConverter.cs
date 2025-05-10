using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

public class BankIdConverter : ValueConverter<BankId, Guid>
{
    public BankIdConverter() : base(e => e.Value,
        id => BankId.Create(id).Value)
    {

    }
    
}
public sealed class BankIdComparer : ValueComparer<BankId>
{
    public BankIdComparer():base(
        (x,y)=>x!.Value==y!.Value,
        x=>x.Value.GetHashCode())
    {
      
    }
}