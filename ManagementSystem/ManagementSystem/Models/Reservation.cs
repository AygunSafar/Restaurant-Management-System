using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ManagementSystem.Helper.Helper;

namespace ManagementSystem.Models
{
    public class Reservation: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public DateTime Day { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public DateTime? StartTime { get; set; }
       [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public DateTime? EndTime { get; set; }
        public bool Isdeactive { get; set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public ReservationStatus Status { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime.Value <= StartTime.Value)
            {
                yield return new ValidationResult("Bitiş Saatı Başlanğıc saatından kiçik ola bilməz.", new[] { "EndTime" });
            }
        }

    }
    
}
