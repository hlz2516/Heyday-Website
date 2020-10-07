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

            return View();
        }
    }
}
