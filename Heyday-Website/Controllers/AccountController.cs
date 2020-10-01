using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.Models;
using Heyday_Website.Tools;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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

        [AllowAnonymous]
        public async Task Test()
        {
            //为了测试方便，这里直接在内存里存一个user对象并登陆
            var user = new ApplicationUser()
            {
                Email = "714251494@qq.com",
                UserName = "aaaa"
            };
            await _userManager.CreateAsync(user);
            await _userManager.AddToRoleAsync(user, "NormalUser");
            await _signInManager.SignInAsync(user, false);
        }

        public IActionResult Login()
        {
            ViewBag.Title = "登录";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user =await  _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var psdhash = new PasswordHasher<ApplicationUser>().
                        HashPassword(user,model.Password);
                    var res = await _signInManager.PasswordSignInAsync(user, model.Password, 
                        model.Remember, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("AccountIndex", "Home");
                    }
                    else Console.WriteLine("登录失败！");
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            ViewBag.Title = "注册";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.TryGetValue(HttpContext.Session.Id,
                    out byte[] _code);
                if(_code == null || _code.Length == 0)
                {
                    return View(model);
                }
                var code = ByteArrayConverter.ToString(_code);
                if(code != model.Code)
                {
                    ModelState.AddModelError("Code", "验证码错误");
                    return View(model);
                }

                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                var hashPassword = new PasswordHasher<ApplicationUser>()
                    .HashPassword(user, model.Password);
                user.PasswordHash = hashPassword;
                var res =await  _userManager.CreateAsync(user);
                if (res.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "NormalUser");
                    await _signInManager.SignInAsync(user, false);
                }
                return RedirectToAction("Index","Home");
            }

            return View(model);
        }

        public IActionResult EmailValidation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmailValidation(EmailValidationDto model)
        {
            if (ModelState.IsValid)
            {
                //Console.WriteLine(model.Email + "," + model.Code);
                HttpContext.Session.TryGetValue(HttpContext.Session.Id,
                   out byte[] _code);
                if (_code == null || _code.Length == 0)
                {
                    return View(model);
                }
                var code = ByteArrayConverter.ToString(_code);
                if (code != model.Code)
                {
                    ModelState.AddModelError("Code", "验证码错误");
                    return View(model);
                }

                var user =await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("ChangePassword");
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var model = new ChangePasswordDto();
            model.Email = (await _userManager.GetUserAsync(HttpContext.User)).Email;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (ModelState.IsValid)
            {
                //Console.WriteLine(model.Email + "," + model.Password);
                var user =await _userManager.GetUserAsync(HttpContext.User);
                var psdhash = new PasswordHasher<ApplicationUser>()
                    .HashPassword(user,model.Password);
                user.PasswordHash = psdhash;
                await Logout();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return View();
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> IsSameEmail(string email)
        {
            var user =await  _userManager.FindByEmailAsync(email);
            if (user != null)
                return Json("邮箱地址已被注册！");
            return Json(true);
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> HasEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Json("邮箱地址不存在！");
            return Json(true);
        }

        public  void SendEmail(string email)
        {
            var code = Guid.NewGuid().ToString().Substring(0, 5);
            HttpContext.Session.Set(HttpContext.Session.Id, 
                ByteArrayConverter.ToByteArray(code));
            EmailHelper.SendEmail(email, code);
        }
    }
}
