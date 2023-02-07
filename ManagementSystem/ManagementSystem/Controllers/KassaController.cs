using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class KassaController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public KassaController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }


        public async Task<IActionResult> Index(Kassa kassa)
        {
            Kassa dbkassa = await _db.Kassas.Include(x => x.AppUser).FirstOrDefaultAsync();
         
           

            return PartialView("_kassaPartialView", dbkassa);
        }


    }
}
