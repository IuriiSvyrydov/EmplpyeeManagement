

namespace EmployeeManagement.Application.Features.Departments
{
    public record DepartmentResponse(
        Guid DepartmentId,
        string Code,
        string Name
        
    );
}