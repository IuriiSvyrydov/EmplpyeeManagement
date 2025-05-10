using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Domain.Entities.Orders.ValueObject;

namespace EmployeeManagement.Domain.Entities.Orders;

public sealed class Order
{

    public OrderId OrderId { get; set; }
    
}