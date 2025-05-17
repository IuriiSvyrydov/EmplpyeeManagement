namespace EmployeeManagement.Application.Features.Banks;

public class BankResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string AccountNo { get; set; }

    public BankResponse()
    {
    }
}