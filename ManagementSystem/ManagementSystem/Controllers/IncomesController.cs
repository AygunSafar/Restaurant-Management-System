using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public IncomesController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Income> incomes = await _db.Incomes.Include(x=>x.AppUser).ToListAsync();
            return View(incomes);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Income income)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedTime = DateTime.UtcNow.AddHours(4);
            kassa.LastModifiedPerson = user.FullName;
            kassa.LastModifiedCause = income.About;
            kassa.LastAmount = income.Money;
       
            kassa.Balance += income.Money;
            kassa.AppUserId = user.Id;


            income.RecordTime = DateTime.UtcNow.AddHours(4);

            income.AppUserId = user.Id;

            await _db.Incomes.AddAsync(income);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }






    }
}
