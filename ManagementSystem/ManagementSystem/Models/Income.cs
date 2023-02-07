using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Income
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
