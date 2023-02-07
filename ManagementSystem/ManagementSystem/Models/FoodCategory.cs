using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class FoodCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Name { get; set; }

        public bool IsDeactive { get; set; }
        public List<Food> Foods { get; set; }
    }
}
