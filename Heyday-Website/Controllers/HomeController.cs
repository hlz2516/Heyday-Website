using Heyday_Website.Models;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heyday_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly Models.AppContext _db;
        private readonly SignInManager<ApplicationUser> _signManager;

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
            var introArticles = _db.Articles.Where(a => a.HasPublished)
                .Where(a => a.Category.CategoryName == "intro")
                .OrderByDescending(a => a.PublishTime)
                .AsEnumerable().Take(5);

            var actArticles = _db.Articles.Where(a => a.HasPublished)
                .Where(a => a.Category.CategoryName == "activity")
                .OrderByDescending(a => a.PublishTime)
                .AsEnumerable().Take(5);

            var allArticles = _db.Articles.Where(a => a.HasPublished)
                .Where(a => a.Category.CategoryName == "others")
                .OrderByDescending(a => a.PublishTime)
                .AsEnumerable().Take(5)
                .Concat(introArticles).Concat(actArticles);

            foreach (var item in allArticles)
            {
                var category = _db.Categories.Find(item.CategoryId);
                Console.WriteLine($"{item.Title}的目录:{category.CategoryName}");
                list.Add(new ArticlesOfIndexDto { Title = item.Title, CategoryName = category.CategoryName });
            }
            return list;
        }
    }
}
