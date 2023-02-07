using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public ExpensesController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Expense> expenses = await _db.Expenses.Include(x => x.AppUser).ToListAsync();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedTime = DateTime.UtcNow.AddHours(4);
            kassa.LastModifiedPerson = user.FullName;
            kassa.LastModifiedCause = expense.About;
            kassa.LastAmount = expense.Money;
        
            kassa.Balance -= expense.Money;
            kassa.AppUserId = user.Id;

            expense.RecordTime = DateTime.UtcNow.AddHours(4);
            expense.AppUserId = user.Id;


            await _db.Expenses.AddAsync(expense);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
