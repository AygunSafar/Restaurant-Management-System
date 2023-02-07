using ManagementSystem.DAL;
using ManagementSystem.Models;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }


      
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM
            {

                Kassa = await _db.Kassas.FirstOrDefaultAsync(),
                Reservation = await _db.Reservations.FirstOrDefaultAsync()


            };
            IQueryable<Reservation> reservationRecord = _db.Reservations;
            var rsCount = reservationRecord.Count();
            ViewBag.ReservationsCount = rsCount;


            IQueryable<Reservation> pnRecords = _db.Reservations.Where(x=>x.Status==Helper.Helper.ReservationStatus.Pending);
            var pnCount = pnRecords.Count();
            ViewBag.PendingCount = pnCount;


            IQueryable<Reservation> cnRecords = _db.Reservations.Where(x => x.Status == Helper.Helper.ReservationStatus.Cancelled);
            var cnCount = cnRecords.Count();
            ViewBag.CancelCount = cnCount;

            IQueryable<Reservation> dnRecords = _db.Reservations.Where(x => x.Status == Helper.Helper.ReservationStatus.Done);
            var dnCount = dnRecords.Count();
            ViewBag.DoneCount = dnCount;

            double incomes30Days = 0;
            incomes30Days = _db.Incomes.Where(w => w.RecordTime >= DateTime.Now.AddDays(-30)).Sum(w => w.Money);
            ViewBag.Incomes30Days = incomes30Days;

            double expense30Days = 0;
            expense30Days = _db.Expenses.Where(w => w.RecordTime >= DateTime.Now.AddDays(-30)).Sum(w => w.Money);
            ViewBag.Expenses30Days = expense30Days;

            double salary = 0;
            salary = _db.Salaries.Where(w => w.PayDate >= DateTime.Now.AddDays(-30)).Sum(w => w.Money);
            ViewBag.Salary30Days = salary;



            return View(homeVM);
        }

      




        public IActionResult Error()
        {
            return View();
        }
    }
}
