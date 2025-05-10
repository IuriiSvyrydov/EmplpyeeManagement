
using EmployeeManagement.Domain.Common.BaseTypes;
using EmployeeManagement.Domain.Common.Results;
using EmployeeManagement.Domain.Entities.Designations.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;

namespace EmployeeManagement.Domain.Entities.Designations
{
    public sealed class Designation : UserActivity
    {
        public DesignationId DesignationId { get; set; }
        public Code Code { get; set; }
        public Name Name { get; set; }
        
    }
}