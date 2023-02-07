using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class Drink
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
        public DrinkCategory DrinkCategory { get; set; }
        public int DrinkCategoryId { get; set; }

    }
}
