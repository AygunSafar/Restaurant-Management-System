using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.ViewModels
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        //[Required]
        public string Role { get; set; }

        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
