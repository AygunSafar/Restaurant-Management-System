using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ManagementSystem.Helper.Helper;

namespace ManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon nömrəsi düzgün daxil edilməyib.")]
        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public DateTime BirthDate { set; get; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public Gender Gender { set; get; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        public bool IsDeactive { get; set; }

        public Job Job { get; set; }

        public int JobId { get; set; }

        public List<Salary> Salaries { get; set; }




    }
}
