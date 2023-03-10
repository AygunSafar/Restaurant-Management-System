using System.ComponentModel.DataAnnotations;
using System;

namespace ManagementSystem.Models
{
    public class Expense
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public double Money { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string About { get; set; }
        public DateTime RecordTime { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
