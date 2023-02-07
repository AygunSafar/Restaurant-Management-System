using ManagementSystem.DAL;
using ManagementSystem.Models;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ManagementSystem.Helper.Helper;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _db;
        public ReservationsController(AppDbContext db, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Reservation> reservations = await _db.Reservations.Include(x => x.Table).Include(x => x.AppUser).ToListAsync();
            return View(reservations);
        }

        public async Task<IActionResult> Create(int tableId)
        {
            ViewBag.Tables = await _db.Tables.Where(x => !x.IsDeactive && !x.IsReserved).ToListAsync();



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Reservation reservation, int tableId)
        {
            ViewBag.Tables = await _db.Tables.Where(x => !x.IsReserved).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Models.Table table = await _db.Tables.FirstOrDefaultAsync(x => x.Id == tableId);
            table.IsReserved = true;

            _db.Entry(table).State = EntityState.Modified;


            reservation.TableId = tableId;
            reservation.AppUserId = user.Id;
            reservation.Status = Helper.Helper.ReservationStatus.Pending;
            await _db.Reservations.AddAsync(reservation);
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Tables = await _db.Tables.Where(x => !x.IsDeactive).ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Reservation dbReservation = await _db.Reservations.Include(x => x.Table).FirstOrDefaultAsync(x => x.Id == id);
            if (dbReservation == null)
            {
                return BadRequest();
            }
            return View(dbReservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Reservation reservation, int? newTableId)
        {
            ViewBag.Tables = await _db.Tables.Where(x => !x.IsDeactive).ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Reservation dbReservation = await _db.Reservations.Include(x => x.Table).FirstOrDefaultAsync(x => x.Id == id);
            if (dbReservation == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbReservation);
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Models.Table table = await _db.Tables.FirstOrDefaultAsync(x => x.Id == newTableId);
   

            if (dbReservation.TableId!= newTableId)
            {
                if (table.IsReserved)
                {
                    ModelState.AddModelError("FullName", "Bu masa rezerv olunub");
                    return View(dbReservation);
                }
                dbReservation.TableId = (int)newTableId;
                table.IsReserved = true;

                dbReservation.Table.IsReserved = false;
                _db.Entry(table).State = EntityState.Modified;
            }

            dbReservation.AppUserId = user.Id;
            dbReservation.FullName = reservation.FullName;
            dbReservation.Notes = reservation.Notes;
            dbReservation.Day = reservation.Day;
            dbReservation.StartTime = reservation.StartTime;
            dbReservation.EndTime = reservation.EndTime;
            dbReservation.Status = reservation.Status;
            if (reservation.Status == ReservationStatus.Done || reservation.Status == ReservationStatus.Cancelled)
            {
                dbReservation.Table.IsReserved = false;
            }
         


            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }



        #region Reservation Activity
        //public async Task<IActionResult> Activity(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Reservation reservation = await _db.Reservations.FirstOrDefaultAsync(x => x.Id == id);
        //    Models.Table table = await _db.Tables.FirstOrDefaultAsync();

        //    if (reservation == null)
        //    {
        //        return BadRequest();
        //    }



        //    if (reservation.Isdeactive)
        //    {

        //        reservation.Isdeactive = false;
        //        table.IsReserved = true;
        //    }
        //    else
        //    {
        //        reservation.Isdeactive = true;
        //        table.IsReserved = false;


        //    }

        //    _db.Entry(table).State = EntityState.Modified;

        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
        #endregion


        //public async Task<IActionResult> Search(SearchVM vm)
        //{
        //    if(vm.StartTime==null|| vm.EndTime == null)
        //    {
        //        return View();
        //    }
        //    var tableReserved = from b in _db.Reservations
        //                        where ((vm.StartTime >= b.StartTime) && (vm.EndTime <= b.EndTime)) ||
        //                        ((vm.EndTime >= b.StartTime) && (vm.EndTime <= b.EndTime)) ||
        //                        ((vm.StartTime <= b.StartTime) && (vm.EndTime >= b.StartTime) && (vm.EndTime <= b.EndTime)) ||
        //                        ((vm.StartTime >= b.StartTime) && (vm.StartTime <= b.EndTime) && (vm.EndTime >= b.StartTime)) ||
        //                        ((vm.StartTime <= b.StartTime) && (vm.EndTime >= b.EndTime))
        //                        select b;
        //    var avaliableTables = _db.Tables.Where(r => !tableReserved.Any(b => b.TableId == r.Id)).ToListAsync();



        //    return View();
        //}

    }
}
