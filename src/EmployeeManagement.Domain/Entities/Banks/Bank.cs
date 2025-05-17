


using EmployeeManagement.Domain.Common.Errors;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.Banks;

public sealed class Bank : UserActivity
{
    public BankId BankId { get; set; }
    public Code Code { get; set; }
    public Name Name { get; set; }
    public AccountNo  AccountNo { get; set; }
    public Bank(){}

    public Bank(BankId bankId, Code code, Name name, AccountNo accountNo)
    {
        BankId = bankId;
        Code = code;
        Name = name;
        AccountNo = accountNo;
    }
    public static ResultT<Bank> Create(Code code, Name name, AccountNo accountNo)
    {
        return new Bank(BankId.NewId(), code, name, accountNo );

       
    }
}
