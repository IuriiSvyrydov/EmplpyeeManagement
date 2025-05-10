namespace EmployeeManagement.UI.Models.UserActivities
{
    public class UserActivity
    {
        public string ? CreateById { get; set; }
        public DateTime CreateOn { get; set; } = DateTime.Now;
        public string ? ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
    }
}