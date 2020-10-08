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
                var categoryId = _db.Categories.Where(c => c.CategoryName == "入门")
                    .Select(c=>c.Id).FirstOrDefault();
                articles = _db.Articles.Where(a=>a.Author == user.Email)
                    .Where(a=>a.CategoryId== categoryId);
            }
            return View(articles);
        }

        public IActionResult NewArticle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewArticle(Article article)
        {
            //Console.WriteLine(article.Content);
            //先检测md/intro下有没有这个标题的md文件
            //如果有，直接覆盖
            //Console.WriteLine(_webHost.WebRootPath);
            var fullPath = Path.Combine(_webHost.WebRootPath, @"md\intro\" + article.Title + ".md");
            //Console.WriteLine(fullPath);
            if (System.IO.File.Exists(fullPath))
            {
                var writer = new StreamWriter(fullPath);
                await writer.WriteAsync(article.Content);
                await writer.FlushAsync();
                writer.Close();
            }
            //如果没有，新建一个article存入数据库，写入对应位置
            else
            {
                var stream = System.IO.File.Create(fullPath);
                var writer = new StreamWriter(stream);
                await writer.WriteAsync(article.Content);
                await writer.FlushAsync();
                writer.Close();

                article.Id = Guid.NewGuid();

                var catagory = _db.Categories.Where(c => c.CategoryName == "入门").FirstOrDefault();
                article.CategoryId = catagory.Id;

                var user = await _userManager.GetUserAsync(HttpContext.User);
                article.Author = user.Email;

                article.HasPublished = false;
                await _db.AddAsync(article);
                await _db.SaveChangesAsync();
            }
            return View(article);
        }
    }
}
