using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class DrinkCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Name { get; set; }

        public bool IsDeactive { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
