using ManagementSystem.DAL;
using ManagementSystem.Models;
using ManagementSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ManagementSystem.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UsersController : Controller

    {
        private readonly UserManager<AppUser> _userManager;
       private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;

        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            List<UserVM> userVMs = new List<UserVM>();
            foreach (AppUser user in users)
            {
                UserVM userVM = new UserVM
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Id = user.Id,
                    IsDeactive = user.IsDeactive,
                    Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                };
                userVMs.Add(userVM);

            }
            return View(userVMs);
           
        }

        public async Task<IActionResult> Activity(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
         
            if (user == null)
            {
                return BadRequest();
            }
            if (user.IsDeactive)
            {
                user.IsDeactive = false;
            }
            else
            {
                user.IsDeactive = true;
            }

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }

        public IActionResult Create()

        {

            List<string> roles = new List<string>();
            
            roles.Add("Admin");
            roles.Add("Reception");
   

            ViewBag.Roles = roles;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateUserVM createUserVM,string addRole)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            List<string> roles = new List<string>();
          
                roles.Add("Admin");
                roles.Add("Reception");
             
            
            ViewBag.Roles = roles;


            AppUser appUser = new AppUser
            {
                FullName = createUserVM.FullName,
                UserName = createUserVM.UserName,
                Email = createUserVM.Email,
                
                
            };
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, createUserVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            IdentityResult addIdentityResult = await _userManager.AddToRoleAsync(appUser, addRole);
            if (!addIdentityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Update(string id)
        {
            List<string> roles = new List<string>();

            roles.Add("Admin");
            roles.Add("Reception");


            
            if (id == null)
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(id);
            if(appUser== null)
            {
                return BadRequest();
            }

            string oldRole = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
            UpdateUserVM dbUser = new UpdateUserVM { 
            
                FullName=appUser.FullName,
                UserName=appUser.UserName,
                Email=appUser.Email,
                Role = oldRole,
                Roles = roles

            };


            return View(dbUser);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> UpdateAsync(string id, UpdateUserVM updateUser,string newRole)
        {
            List<string> roles = new List<string>();

            roles.Add("Admin");
            roles.Add("Reception");
         


            if (id == null)
            {
                return NotFound();
            }

            AppUser appUser = await _userManager.FindByIdAsync(id);
            if (appUser == null)
            {
                return BadRequest();
            }

            string oldRole = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
            UpdateUserVM dbUser = new UpdateUserVM
            {

                FullName = appUser.FullName,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Role = oldRole,
                Roles = roles

            };
            if (!ModelState.IsValid)
            {
                return View(dbUser);
            }

            bool isExistName = await _db.Users.AnyAsync(x => x.UserName == updateUser.UserName && x.Id != id);
            if (isExistName)
            {
                ModelState.AddModelError("UserName", "This Username is already exist");
                return View(dbUser);
            }
            bool isExistEmail = await _db.Users.AnyAsync(x => x.Email == updateUser.Email && x.Id != id);
            if (isExistEmail)
            {
                ModelState.AddModelError("Email", "This Email is already exist");
                return View(dbUser);
            }
            if (oldRole != newRole)
            {
                IdentityResult addIdentityResult = await _userManager.AddToRoleAsync(appUser, newRole);
                if (!addIdentityResult.Succeeded)
                {
                    ModelState.AddModelError("", "Error");
                    return View(dbUser);
                }
                IdentityResult removeIdentityResult = await _userManager.RemoveFromRoleAsync(appUser, oldRole);
                if (!removeIdentityResult.Succeeded)
                {
                    ModelState.AddModelError("", "Error");
                    return View(dbUser);
                }
            }

           
            appUser.FullName = updateUser.FullName;
            appUser.UserName = updateUser.UserName;
            appUser.Email = updateUser.Email;

            
            await _userManager.UpdateAsync(appUser);
            _db.SaveChanges();


            return RedirectToAction("Index");
        }


        //public async Task<IActionResult> Delete(string id)
        //{

        //    AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    UserVM deleteUser = new UserVM
        //    { 
        //        UserName=user.UserName
            
        //    };

        //    await _userManager.DeleteAsync(user);
        //    await _db.SaveChangesAsync();

        //    return View(deleteUser);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public async Task<IActionResult> DeletePost(string id)
        //{

        //    AppUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    await _userManager.DeleteAsync(user);
        //    await _db.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}




        //public async Task<List<string>> GetRoles()
        //{
        //    List<string> roles = await _roleManager.Roles.Select(x => x.Name).ToListAsync();

        //    return roles;
        //}

    }
}
