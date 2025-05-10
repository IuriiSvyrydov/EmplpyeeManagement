using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Domain.Entities.Orders.ValueObject;

public class OrderId: ValueObject<Guid>
{
    private OrderId(){}
    public OrderId(Guid value) : base(value)
    {
    }
    public static ValidationResult<OrderId?> Create(Guid value)
    {
        var errors = new List<string>();
        if (value == Guid.Empty) errors.Add(("OrderId cannot be empty"));
        return errors.Count==0? ValidationResult<OrderId?>.Success(new OrderId(value))
            :ValidationResult<OrderId?>.Failed(errors);
      
    }
    public static OrderId? NewId()
        => new OrderId(Guid.NewGuid());
}