using ManagementSystem.DAL;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly AppDbContext _db;
       
        public MenuController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
           
        }
        public async Task<IActionResult> Index(int id)
        {
            MenuVM menuVM = new MenuVM
            {

                DrinkCategories = await _db.DrinkCategories.Where(x => !x.IsDeactive).ToListAsync(),
                FoodCategories = await _db.FoodCategories.Where(x => !x.IsDeactive).ToListAsync(),
                Drinks = await _db.Drinks.Where(x => !x.IsDeactive).ToListAsync(),
                Foods = await _db.Foods.Where(x => !x.IsDeactive).ToListAsync(),
                


            };
            return View(menuVM);
        }
    }
}
