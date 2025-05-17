
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.SystemCodes
{
    public sealed class SystemCode : UserActivity
    {
        [Key]
        public SystemCodeId SystemCodeId { get; set; }
        public Code Code { get; set; }
        public Description Description { get; set; }
        
    }
}