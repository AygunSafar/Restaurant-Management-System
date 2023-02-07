using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class PaidSalariesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public PaidSalariesController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Salary> salaries = await _db.Salaries.Include(x=>x.AppUser).Include(x => x.Employee).ToListAsync();
            return View(salaries);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Employees = await _db.Employees.Where(x => !x.IsDeactive).ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Salary salary,int empId,string about)
        {
            ViewBag.Employees = await _db.Employees.Where(x => !x.IsDeactive).ToListAsync();
            
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            salary.PayDate = DateTime.UtcNow.AddHours(4);
          
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x=>x.Id==empId);
            if (employee == null)
            {
                return BadRequest();
            }
            salary.Money = employee.Salary;
            salary.About = employee.FullName +" adlı işçinin Əmək Haqqı ödənişi";


            salary.AppUserId = user.Id;
            salary.EmployeeId = empId;
            Kassa kassa = await _db.Kassas.FirstOrDefaultAsync();
            kassa.LastModifiedTime = DateTime.UtcNow.AddHours(4);
            kassa.LastModifiedPerson = user.FullName;
            kassa.LastModifiedCause = salary.About;
            kassa.LastAmount = salary.Money;
            kassa.Balance -= salary.Money;
            kassa.AppUserId = user.Id;
            

            await _db.Salaries.AddAsync(salary);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
