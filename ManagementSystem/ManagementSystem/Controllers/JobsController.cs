using ManagementSystem.DAL;
using ManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class JobsController : Controller


    {
        private readonly AppDbContext _db;

        public JobsController(AppDbContext db)
        {
            _db = db;

        }
        public async Task<IActionResult> Index()
        {

            List<Job> jobs = await _db.Jobs.ToListAsync();
            return View(jobs);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Jobs.AnyAsync(x => x.Name == job.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda vəzifə mövcuddur.");
                return View();
            }
            await _db.Jobs.AddAsync(job);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Job dbJob = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbJob == null)
            {
                return BadRequest();
            }

            return View(dbJob);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Job job)
        {
            if (id == null)
            {
                return NotFound();
            }
            Job dbJob = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (dbJob == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbJob);
            }
            bool isExist = await _db.Jobs.AnyAsync(x => x.Name == job.Name);
            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda vəzifə mövcuddur.");
                return View(dbJob);
            }
            dbJob.Name = job.Name;
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Job job = await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (job == null)
            {
                return BadRequest();
            }
            if (job.IsDeactive)
            {
                job.IsDeactive = false;
            }
            else
            {
                job.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
