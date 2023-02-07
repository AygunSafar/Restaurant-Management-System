using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrə Təsdiqi ilə Şifrə uyuşmur")]
        public string ConfirmPassword { get; set; }



    }
}
