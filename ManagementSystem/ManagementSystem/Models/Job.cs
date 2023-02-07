using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zəhmət olmasa, vəzifə adı daxil edin.")]
        public string Name { get; set; }
        public bool IsDeactive { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
