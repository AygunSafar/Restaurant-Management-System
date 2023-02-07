using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
