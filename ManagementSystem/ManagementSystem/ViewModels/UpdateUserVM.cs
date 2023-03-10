using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class UpdateUserVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Role { get; set; }
        public List<string> Roles { get; set; }
    }
}
