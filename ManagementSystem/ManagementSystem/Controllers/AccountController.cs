using ManagementSystem.DAL;
using ManagementSystem.Helper;
using ManagementSystem.Models;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace ManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;
        public AccountController(UserManager<AppUser> userManager,
                                SignInManager<AppUser> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                AppDbContext db)

        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        #region Account Login
        public async Task<IActionResult> Login()
        {

            var hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            bool result = hasAdmin.HasAdmins;
            ViewBag.CheckAdmin = result;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            bool result = hasAdmin.HasAdmins;
            ViewBag.CheckAdmin = result;


            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya Şifrə yanlışdır.");
                return View();
            }
            if (user.IsDeactive)
            {
                ModelState.AddModelError("Password", "Bu istifadəçi bloklanıb. ");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("Password", "Sistemə girişiniz bir dəqiqəliyinə bloklandı.");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("Password", "İstifadəçi adı və ya Şifrə yanlışdır.");
                return View();
            }

            return RedirectToAction("Index", "Home");


        }

        #endregion



        #region Create Admin
        public async Task<IActionResult> CreateAdmin()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await CreateRoles();
            var result = await _userManager.FindByNameAsync("Admin");

            if (result == null)
            {
                AppUser appUser = new AppUser
                {
                    FullName = "Admin",
                    UserName = "Admin",
                    Email = "Admin@admin.com",

                };
                IdentityResult identityResult = await _userManager.CreateAsync(appUser, "Admin12345");
                if (!identityResult.Succeeded)
                {
                    foreach (IdentityError error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }

                await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

            }
            else
            {
                return NotFound();
            }
            Helper.HasAdmin hasAdmin = await _db.HasAdmins.FirstOrDefaultAsync();
            hasAdmin.HasAdmins = true;

            await _db.SaveChangesAsync();

            return RedirectToAction("Login");
        }
        #endregion


        #region Logout
        public async Task<IActionResult> Logout()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return View("Error");
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        #endregion


        #region Creat eRoles
        public async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
            }
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!await _roleManager.RoleExistsAsync("Reception"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Reception" });
            }

        }
        #endregion

        #region Forget Password
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email adress mövcud deyil.");
                return View();
            }


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetUrl = $"https://localhost:44306/Account/ResetPassword?token={token}";



            using (var client = new SmtpClient("smtp.yandex.com", 587))
            {
                client.Credentials = new NetworkCredential("aygun.s@itbrains.edu.az", "hhenmmrupduhmrjx");
                client.EnableSsl = true;

                var message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("aygun.s@itbrains.edu.az");
                message.To.Add(new MailAddress(user.Email));
                message.Subject = "Şifrənizi sıfırlayın";
                message.Body = $"Please reset your password by clicking <a href='{resetUrl}'>here</a>";

                await client.SendMailAsync(message);
            }

            return View();
        }
        #endregion



        #region ResetPassword
        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Login");
            }
            return View(new ResetPasswordViewModel { Token = token });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email adress mövcud deyil.");
                return View();
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Login");
        }
        #endregion

    }
}


