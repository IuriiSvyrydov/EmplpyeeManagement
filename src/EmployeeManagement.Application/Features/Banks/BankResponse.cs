namespace EmployeeManagement.Application.Features.Banks;

public record BankResponse(
    Guid Id,
    string Code,
    string Name,
    string AccountNo);