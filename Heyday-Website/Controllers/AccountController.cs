using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.Models;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Heyday_Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            InitRoles().Wait();
        }

        private async Task InitRoles()
        {
            if (!await _roleManager.RoleExistsAsync("NormalUser"))
                await _roleManager.CreateAsync(new IdentityRole("NormalUser"));
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await _roleManager.RoleExistsAsync("Root"))
                await _roleManager.CreateAsync(new IdentityRole("Root"));
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.Title = "注册";
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult FindPassword()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
