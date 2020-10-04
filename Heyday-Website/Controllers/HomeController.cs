using Heyday_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Heyday_Website.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<ApplicationUser> _signManager;

        public HomeController(SignInManager<ApplicationUser> signManager)
        {
            _signManager = signManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (_signManager.IsSignedIn(HttpContext.User))
                return RedirectToAction("AccountIndex");
            return View();
        }
        [Authorize]
        public IActionResult AccountIndex()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            //foreach (var item in HttpContext.User.Claims)
            //{
            //    Debug.WriteLine(item.Type + "," + item.Value);
            //}
            return View();
        }
    }
}
