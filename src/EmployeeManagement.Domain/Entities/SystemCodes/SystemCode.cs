
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.SystemCodes
{
    public sealed class SystemCode : UserActivity
    {
        public SystemCodeId Id { get; set; }
        public Code Code { get; set; }
        public Description Description { get; set; }
        
    }
}