using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class FoodCategoryController : Controller
    {

        private readonly AppDbContext _db;

        public FoodCategoryController(AppDbContext db)
        {
            _db = db;

        }
        public async Task<IActionResult> Index()
        {
          List<FoodCategory>foodCategories = await _db.FoodCategories.ToListAsync();

            return View(foodCategories);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodCategory foodCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.FoodCategories.AnyAsync(x => x.Name == foodCategory.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kateqoriya artıq mövcuddur.");
                return View();
            }
            await _db.FoodCategories.AddAsync(foodCategory);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

 

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FoodCategory dbCategory = await _db.FoodCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }

            return View(dbCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, FoodCategory foodCategory)
        {
            if (id == null)
            {
                return NotFound();
            }
            FoodCategory dbCategory = await _db.FoodCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (dbCategory == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbCategory);
            }
            bool isExist = await _db.FoodCategories.AnyAsync(x => x.Name == foodCategory.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu kateqoriya artıq mövcuddur.");
                return View(dbCategory);
            }
            dbCategory.Name = foodCategory.Name;
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            FoodCategory foodCategory = await _db.FoodCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (foodCategory == null)
            {
                return BadRequest();
            }
            if (foodCategory.IsDeactive)
            {
                foodCategory.IsDeactive = false;
            }
            else
            {
                foodCategory.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
