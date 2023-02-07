using System;

namespace ManagementSystem.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public double Money { get; set; }
        public string About { get; set; }
        public DateTime PayDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }




    }
}
