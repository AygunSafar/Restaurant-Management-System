using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class LoginVM
    {

        [Required(ErrorMessage = "İstifadəçi adını daxil edin.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifrəni daxil edin.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
