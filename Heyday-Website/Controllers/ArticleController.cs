using Heyday_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heyday_Website.Controllers
{
    public class ArticleController : Controller
    {
        private Models.AppContext _db;
        private IWebHostEnvironment _webHost;
        private UserManager<ApplicationUser> _userManager;

        public ArticleController(Models.AppContext context,IWebHostEnvironment webHost,UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _webHost = webHost;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Getmd()
        {
            var mdpath = Path.Combine(_webHost.WebRootPath + @"\md\test.md");
            Console.WriteLine(mdpath);
            var reader = new StreamReader(mdpath,Encoding.Default);
            var res = new StringBuilder();
            string content;
            while ((content = reader.ReadLine()) != null)
            {
                res.Append(content + '\n');
            }
            return res.ToString();
        }

        public async Task<IActionResult> Introduction()
        {
            //查询该用户所有的入门类别的文章返回给视图
            var user =await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<Article> articles=null;
            if (user != null)
            {
                articles = _db.Articles.Where(a=>a.Author == user.Email)
                    .Where(a=>a.Category.CategoryName == "入门");
            }
            return View(articles);
        }

        public IActionResult NewArticle()
        {
            return View();
        }
    }
}
