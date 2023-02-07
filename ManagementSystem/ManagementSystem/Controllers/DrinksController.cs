using ManagementSystem.DAL;
using ManagementSystem.Helper;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class DrinksController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public DrinksController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Drink> drinks = await _db.Drinks.Include(x => x.DrinkCategory).ToListAsync();

            return View(drinks);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.DrinkCategories = await _db.DrinkCategories.Where(x => !x.IsDeactive).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Drink drink, int catId)
        {

            ViewBag.DrinkCategories = await _db.DrinkCategories.Where(x => !x.IsDeactive).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Drinks.AnyAsync(x => x.Name == drink.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Yemək artıq mövcuddur.");
                return View();
            }
            if (drink.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil faylı əlavə edin");
                return View();
            }
            if (!drink.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", " Şəkil əlavə edin");
                return View();
            }
            if (drink.Photo.IsOlder1MB())
            {
                ModelState.AddModelError("Photo", " Şəkilin ölçüsü 1 mb-dan çox olmamalıdır");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "images");
            drink.Image = await drink.Photo.SaveFileAsync(folder);

            drink.DrinkCategoryId = catId;
            await _db.Drinks.AddAsync(drink);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            ViewBag.DrinkCategories = await _db.DrinkCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Drink drink = await _db.Drinks.Include(x => x.DrinkCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (drink == null)
            {
                return BadRequest();
            }
            return View(drink);

        }
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.DrinkCategories = await _db.DrinkCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Drink dbDrink = await _db.Drinks.Include(x => x.DrinkCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (dbDrink == null)
            {
                return BadRequest();
            }
            return View(dbDrink);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Drink drink, int catId)
        {
            ViewBag.DrinkCategories = await _db.DrinkCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Drink dbDrink = await _db.Drinks.Include(x => x.DrinkCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (dbDrink == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbDrink);
            }
            bool isExist = await _db.Drinks.AnyAsync(x => x.Name == drink.Name && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu product movcuddur");
                return View(dbDrink);
            }
            if (drink.Photo != null)
            {
                if (!drink.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", " sekil elave edin");
                    return View(dbDrink);
                }
                if (drink.Photo.IsOlder1MB())
                {
                    ModelState.AddModelError("Photo", " 1 mb");
                    return View(dbDrink);
                }
                string folder = Path.Combine(_env.WebRootPath, "images");
                string path = Path.Combine(folder, dbDrink.Image);
                if (System.IO.File.Exists(folder))
                {
                    System.IO.File.Delete(path);
                }
                dbDrink.Image = await drink.Photo.SaveFileAsync(folder);
                dbDrink.Image = await drink.Photo.SaveFileAsync(folder);
            }
            dbDrink.DrinkCategoryId = catId;
            dbDrink.Name = drink.Name;
            dbDrink.Ingredients = drink.Ingredients;
            dbDrink.Price = drink.Price;

            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Drink drink = await _db.Drinks.FirstOrDefaultAsync(x => x.Id == id);
            if (drink == null)
            {
                return BadRequest();
            }
            if (drink.IsDeactive)
            {
                drink.IsDeactive = false;
            }
            else
            {
                drink.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

