using Heyday_Website.Models;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly Models.AppDbContext _db;
        private readonly SignInManager<ApplicationUser> _signManager;

        public HomeController(Models.AppDbContext context,SignInManager<ApplicationUser> signManager)
        {
            _db = context;
            _signManager = signManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            
            if (_signManager.IsSignedIn(HttpContext.User))
                return RedirectToAction("AccountIndex");
            return View(await GetArticles());
        }

        [Authorize]
        public async Task<IActionResult> AccountIndex()
        {

            return View("Index",await GetArticles());
        }

        public async Task<IEnumerable<ArticlesOfIndexDto>> GetArticles()
        {
            IList<ArticlesOfIndexDto> list = new List<ArticlesOfIndexDto>();

            var allArticles = await _db.Articles.Where(a => a.HasPublished)
                .OrderByDescending(a => a.PublishTime).ToListAsync();

            foreach (var item in allArticles)
            {
                var category = _db.Categories.Find(item.CategoryId);
                //Console.WriteLine($"{item.Title}的目录:{category.CategoryName}");
                list.Add(new ArticlesOfIndexDto { Title = item.Title, CategoryName = category.CategoryName });
            }
            return list;
        }
    }
}
