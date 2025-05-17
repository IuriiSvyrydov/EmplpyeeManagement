using EmployeeManagement.Domain.Entities.Orders.ValueObject;
using EmployeeManagement.Domain.Entities.SystemCodeDetails.ValueObject;
using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using EmployeeManagement.Domain.Entities.UserActivities;
using Code = EmployeeManagement.Domain.Entities.Departments.ValueObject.Code;

namespace EmployeeManagement.Domain.Entities.SystemCodeDetails;

public sealed class SystemCodeDetail : UserActivity
    {
        public SystemCodeDetailId Id { get; set; }
        public Guid SystemCodeId { get; set; }
        public SystemCode SystemCode { get; set; }
        public Code  Code { get; set; }
        public Description Description { get; set; }
       // public OrderId? OrderId { get; set; }
        
        
    }
