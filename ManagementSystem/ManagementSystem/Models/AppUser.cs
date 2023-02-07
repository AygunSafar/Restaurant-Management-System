using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ManagementSystem.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

        public bool IsDeactive { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Kassa> Kassas { get; set; }
        public List<Salary> Salaries { get; set; }
      
    }
}
