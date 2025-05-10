using System.Linq.Expressions;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Orders.ValueObject;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Persistence.Converters;

internal class OrderIdConverter : ValueConverter<OrderId, Guid>
{
    public OrderIdConverter() : base(
        e => e.Value,
        id => new OrderId(id))
    {
    }
}

public sealed class OrderIdComparer : ValueComparer<OrderId>
{
    public OrderIdComparer() : base(
        (x, y) => x!.Value == y!.Value,
        x => x.Value.GetHashCode(),
        x => new OrderId(x.Value))
    {
    }
}