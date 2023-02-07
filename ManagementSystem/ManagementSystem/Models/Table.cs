using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Name { get; set; }
      
        public string Description { get; set; }
        public bool IsDeactive { get; set; }
        public bool IsReserved { get; set; }
        public List<Reservation> Reservations  { get; set; }


    }
}
