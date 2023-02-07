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
    public class TablesController : Controller
    {
        private readonly AppDbContext _db;

        public TablesController(AppDbContext db)
        {
            _db = db;

        }
        public async Task<IActionResult> Index()
        {
            List<Table> tables = await _db.Tables.ToListAsync();
            return View(tables);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Table table)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Tables.AnyAsync(x => x.Name == table.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda masa mövcuddur.");
                return View();
            }
            await _db.Tables.AddAsync(table);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Table dbTable = await _db.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if (dbTable == null)
            {
                return BadRequest();
            }

            return View(dbTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Table table)
        {
            if (id == null)
            {
                return NotFound();
            }
            Table dbTable = await _db.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if (dbTable == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbTable);
            }
            bool isExist = await _db.Jobs.AnyAsync(x => x.Name == table.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda vəzifə mövcuddur.");
                return View(dbTable);
            }
            dbTable.Name = table.Name;
            dbTable.Description = table.Description;
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Table table = await _db.Tables.FirstOrDefaultAsync(x => x.Id == id);
            if (table == null)
            {
                return BadRequest();
            }
            if (table.IsDeactive)
            {
                table.IsDeactive = false;
                table.IsReserved = false;
            }
            else
            {
                table.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
