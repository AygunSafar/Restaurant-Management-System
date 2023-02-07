using ManagementSystem.DAL;
using ManagementSystem.Models;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ManagementSystem.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _db;
        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _db.Employees.Include(x => x.Job).Include(x=>x.Salaries).ToListAsync();
            return View(employees);
        }

        #region  Employee Create
        public async Task<IActionResult> Create(int jobId)
        {
            ViewBag.Jobs = await _db.Jobs.Where(x => !x.IsDeactive).ToListAsync();



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Employee employee, int jobId)
        {
            ViewBag.Jobs = await _db.Jobs.Where(x => !x.IsDeactive).ToListAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }


            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        #endregion

        #region Employee Update
        public async Task<IActionResult> Update(int? id, int jobId)
        {
            ViewBag.Jobs = await _db.Jobs.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Employee dbEmployee = await _db.Employees.Include(x => x.Job).FirstOrDefaultAsync(x => x.Id == id);
            if (dbEmployee == null)
            {
                return BadRequest();
            }
            return View(dbEmployee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Employee employee, int jobId)
        {
            ViewBag.Jobs = await _db.Jobs.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            Employee dbEmployee = await _db.Employees.Include(x => x.Job).FirstOrDefaultAsync(x => x.Id == id);
            if (dbEmployee == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbEmployee);
            }

            dbEmployee.JobId = jobId;
            dbEmployee.FullName = employee.FullName;
            dbEmployee.FatherName = employee.FatherName;
            dbEmployee.Gender = employee.Gender;
            dbEmployee.Email = employee.Email;
            dbEmployee.PhoneNumber = employee.PhoneNumber;
            dbEmployee.BirthDate = employee.BirthDate;
            dbEmployee.Salary = employee.Salary;

            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }
        #endregion

        #region Employee Detail
        public async Task<IActionResult> Detail(int? id)
        {
            ViewBag.Jobs = await _db.Jobs.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _db.Employees.Include(x => x.Job).FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return BadRequest();
            }
            return View(employee);

        }
        #endregion

        #region Send Mail 1 Employee
        public async Task<IActionResult> SendMail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return BadRequest();
            }
            EmployeeVM employeeVM = new EmployeeVM
            {
                FullName = employee.FullName,
                Email = employee.Email
            };
            ViewBag.Info = employeeVM;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMail(int? id, Email email)
        {


            if (id == null)
            {
                return NotFound();
            }

            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return BadRequest();
            }
            EmployeeVM employeeVM = new EmployeeVM
            {
                FullName = employee.FullName,
                Email = employee.Email
            };
            ViewBag.Info = employeeVM;


            SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("aygun.s@itbrains.edu.az", "hhenmmrupduhmrjx");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage("aygun.s@itbrains.edu.az", employeeVM.Email);
            message.Subject = email.Subject;
            message.Body = email.Body;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;


            List<Attachment> attachments = new List<Attachment>();
            if (email.Files != null && email.Files.Count > 0)
            {
                foreach (var file in email.Files)
                {
                    Attachment attachment = new Attachment(file.OpenReadStream(), file.FileName);
                    attachments.Add(attachment);
                    foreach (var item in attachments)
                    {
                        message.Attachments.Add(item);
                    }

                }

            }

            try
            {
                await client.SendMailAsync(message);
                TempData["Message"] = "Mail göndərildi";
            }
            catch (System.Exception ex)
            {

                TempData["Message"] = "Mail göndərilmədi" + ex.Message;
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region SendEmail All Employees
        public async Task<IActionResult> SendMailAll()
        {

            ViewBag.Employees = await _db.Employees.Where(x => !x.IsDeactive).ToListAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SendMailAll(Email email)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<Employee> employees = await _db.Employees.ToListAsync();


            foreach (var employee in employees)
            {
                SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("aygun.s@itbrains.edu.az", "hhenmmrupduhmrjx");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage message = new MailMessage("aygun.s@itbrains.edu.az", employee.Email);
                message.Subject = email.Subject;
                message.Body = email.Body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                List<Attachment> attachments = new List<Attachment>();
                if (email.Files != null && email.Files.Count > 0)
                {
                    foreach (var file in email.Files)
                    {
                        Attachment attachment = new Attachment(file.OpenReadStream(), file.FileName);
                        attachments.Add(attachment);
                        foreach (var item in attachments)
                        {
                            message.Attachments.Add(item);
                        }

                    }

                }
                try
                {
                    await client.SendMailAsync(message);
                    TempData["Message"] = "Mail göndərildi";
                }
                catch (System.Exception ex)
                {

                    TempData["Message"] = "Mail göndərilmədi" + ex.Message;
                    return View();
                }
            }



            return RedirectToAction("Index");
        }
        #endregion

        #region Employee Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                return BadRequest();
            }
            if (employee.IsDeactive)
            {
                employee.IsDeactive = false;
            }
            else
            {
                employee.IsDeactive = true;
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion




    }
}
