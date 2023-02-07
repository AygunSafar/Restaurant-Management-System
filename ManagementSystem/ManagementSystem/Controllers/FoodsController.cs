using ManagementSystem.DAL;
using ManagementSystem.Helper;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class FoodsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public FoodsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Food> foods = await _db.Foods.Include(x => x.FoodCategory).ToListAsync();

            return View(foods);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.FoodCategories = await _db.FoodCategories.Where(x => !x.IsDeactive).ToListAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Food food, int catId)
        {

            ViewBag.FoodCategories = await _db.FoodCategories.Where(x => !x.IsDeactive).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Foods.AnyAsync(x => x.Name == food.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu Yemək artıq mövcuddur.");
                return View();
            }
            if (food.Photo == null)
            {
                ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil faylı əlavə edin");
                return View();
            }
            if (!food.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", " Şəkil əlavə edin");
                return View();
            }
            if (food.Photo.IsOlder1MB())
            {
                ModelState.AddModelError("Photo", " Şəkilin ölçüsü 1 mb-dan çox olmamalıdır");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "images");
            food.Image = await food.Photo.SaveFileAsync(folder);

            food.FoodCategoryId = catId;
            await _db.Foods.AddAsync(food);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            ViewBag.FoodCategories = await _db.FoodCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Food food = await _db.Foods.Include(x => x.FoodCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (food == null)
            {
                return BadRequest();
            }
            return View(food);

        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.FoodCategories = await _db.FoodCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Food dbFood = await _db.Foods.Include(x => x.FoodCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (dbFood == null)
            {
                return BadRequest();
            }
            return View(dbFood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Food food, int catId)
        {
            ViewBag.FoodCategories = await _db.FoodCategories.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Food dbFood = await _db.Foods.Include(x => x.FoodCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (dbFood == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbFood);
            }
            bool isExist = await _db.Foods.AnyAsync(x => x.Name == food.Name && x.Id != id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu product movcuddur");
                return View(dbFood);
            }
            if (food.Photo != null)
            {
                if (!food.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", " sekil elave edin");
                    return View(dbFood);
                }
                if (food.Photo.IsOlder1MB())
                {
                    ModelState.AddModelError("Photo", " 1 mb");
                    return View(dbFood);
                }
                string folder = Path.Combine(_env.WebRootPath, "images");
                string path = Path.Combine(folder, dbFood.Image);
                if (System.IO.File.Exists(folder))
                {
                    System.IO.File.Delete(path);
                }
                dbFood.Image = await food.Photo.SaveFileAsync(folder);
                dbFood.Image = await food.Photo.SaveFileAsync(folder);
            }
            dbFood.FoodCategoryId = catId;
            dbFood.Name = food.Name;
            dbFood.Ingredients = food.Ingredients;
            dbFood.Price = food.Price;
         
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Food food = await _db.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null)
            {
                return BadRequest();
            }
            if (food.IsDeactive)
            {
                food.IsDeactive = false;
            }
            else
            {
                food.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

