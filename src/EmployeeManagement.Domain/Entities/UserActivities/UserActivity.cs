using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities.UserActivities
{
    public class UserActivity
    {
        public string ? CreateById { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public string ? ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}