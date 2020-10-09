using Heyday_Website.Models;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Heyday_Website.Controllers
{
    public class HomeController : Controller
    {
        private Models.AppContext _db;
        private SignInManager<ApplicationUser> _signManager;

        public HomeController(Models.AppContext context,SignInManager<ApplicationUser> signManager)
        {
            _db = context;
            _signManager = signManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            
            if (_signManager.IsSignedIn(HttpContext.User))
                return RedirectToAction("AccountIndex");
            return View(GetArticles());
        }

        [Authorize]
        public IActionResult AccountIndex()
        {

            return View("Index",GetArticles());
        }

        public IEnumerable<ArticlesOfIndexDto> GetArticles()
        {
            IList<ArticlesOfIndexDto> list = new List<ArticlesOfIndexDto>();
            var articleTitles = _db.Articles.Where(a => a.HasPublished).AsEnumerable();
            foreach (var item in articleTitles)
            {
                var category = _db.Categories.Find(item.CategoryId);
                list.Add(new ArticlesOfIndexDto { Title = item.Title, CategoryName = category.CategoryName });
            }
            return list;
        }
    }
}
