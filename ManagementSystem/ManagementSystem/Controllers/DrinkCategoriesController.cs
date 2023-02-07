using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
  
    public class DrinkCategoriesController : Controller
    {
        private readonly AppDbContext _db;

        public DrinkCategoriesController(AppDbContext db)
        {
            _db = db;

        }
        public async Task<IActionResult> Index()
        {
            List<DrinkCategory> drinkCategories = await _db.DrinkCategories.ToListAsync();

            return View(drinkCategories);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrinkCategory drinkCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.DrinkCategories.AnyAsync(x => x.Name == drinkCategory.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kateqoriya artıq mövcuddur.");
                return View();
            }
            await _db.DrinkCategories.AddAsync(drinkCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DrinkCategory dbCategory = await _db.DrinkCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }

            return View(dbCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, DrinkCategory drinkCategory)
        {
            if (id == null)
            {
                return NotFound();
            }
            DrinkCategory dbCategory = await _db.DrinkCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbCategory);
            }
            bool isExist = await _db.DrinkCategories.AnyAsync(x => x.Name == drinkCategory.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kateqoriya artıq mövcuddur.");
                return View(dbCategory);
            }
            dbCategory.Name = drinkCategory.Name;
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DrinkCategory drinkCategory = await _db.DrinkCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (drinkCategory == null)
            {
                return BadRequest();
            }
            if (drinkCategory.IsDeactive)
            {
                drinkCategory.IsDeactive = false;
            }
            else
            {
                drinkCategory.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

