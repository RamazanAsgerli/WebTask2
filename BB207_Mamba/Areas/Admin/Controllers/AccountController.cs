using BB207_Mamba.ViewModels;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BB207_Mamba.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(UserManager<User> userManager, SignInManager<User> signManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User()
        //    {
        //        Name = "admin",
        //        Surname = "adminov",
        //    };
        //    await _userManager.CreateAsync(admin, "Admin123@");
        //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

        //    return Ok("Admin yarandi");

        //}

        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole identityRole = new IdentityRole("SuperAdmin");
        //    IdentityRole identityRole2 = new IdentityRole("Admin");
        //    IdentityRole identityRole3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(identityRole);
        //    await _roleManager.CreateAsync(identityRole2);
        //    await _roleManager.CreateAsync(identityRole3);

        //    return Ok("Rollar Yarandi");

        //}
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVm adminLoginVm)
        {
            if(!ModelState.IsValid) return View();
            User user=await _userManager.FindByNameAsync(adminLoginVm.UserName);
            if(user==null)
            {
                ModelState.AddModelError("", "User ve ya sifre sehvdirrr!!!!");
                return View();
            }
          var result = await _signManager.PasswordSignInAsync(user, adminLoginVm.Password, adminLoginVm.IsPersistent, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "User ve ya sifre sehvdirrr!!!!");
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
