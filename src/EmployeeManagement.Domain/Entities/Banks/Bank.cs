


using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.Banks;

public sealed class Bank : UserActivity
{
    public BankId BankId { get; set; }
    public Code Code { get; set; }
    public Name Name { get; set; }
    public AccountNo  AccountNo { get; set; }
}
