using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Models
{
    public class Food
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public string Ingredients { get; set; }
        [Required(ErrorMessage = "Xana boş saxlanıla bilməz.")]
        public double Price { get; set; }
  
        public string Image { get; set; }
        public bool IsDeactive { get; set; }
        [NotMapped]
    
        public IFormFile Photo { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public int FoodCategoryId { get; set; }



    }
}
