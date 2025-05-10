namespace EmployeeManagement.Application.Features.Banks
{
    public record CreateBankResponse(
        Guid Id,
        string Code,
        string Name,
        string AccountNo);
}