using ManagementSystem.Models;
using System.Collections.Generic;

namespace ManagementSystem.ViewModels
{
    public class MenuVM
    {
        public List<FoodCategory> FoodCategories { get; set; }
        public List<DrinkCategory> DrinkCategories { get; set; }
        public List<Food> Foods { get; set; }
        public List<Drink> Drinks { get; set; }
    }
}
