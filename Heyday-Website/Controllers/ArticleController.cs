using Heyday_Website.Models;
using Heyday_Website.ViewModels;
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

        public ArticleController(Models.AppContext context,
            IWebHostEnvironment webHost,
            UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _webHost = webHost;
            _userManager = userManager;
        }
        //get请求
        //Article/Introduction
        //article/activities
        //article/others
        public IActionResult Index()
        {
            return View();
        }

        public string Getmd()
        {
            var mdpath = Path.Combine(_webHost.WebRootPath, @"md\test.md");
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
        //get请求:
        //新建文章：article/writearticle/?cateName="intro"&title=""
        //编辑文章：article/writearticle/?cateName="intro"&title="XXX"
        public async Task<IActionResult> Introduction()
        {
            //查询该用户所有的Introduction类别的文章标题返回给视图
            var user =await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<string> titles=null;
            if (user != null)
            {
                var categoryId = _db.Categories.Where(c => c.CategoryName == "intro")
                    .Select(c=>c.Id).FirstOrDefault();
                titles = _db.Articles.Where(a=>a.Author == user.Email)
                    .Where(a=>a.CategoryId== categoryId)
                    .Select(a=>a.Title);
            }
            return View(titles);
        }

        public async Task<IActionResult> Activity()
        {
            //查询该用户所有的activity类别的文章返回给视图
            var user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<string> titles = null;
            if (user != null)
            {
                var categoryId = _db.Categories.Where(c => c.CategoryName == "activity")
                    .Select(c => c.Id).FirstOrDefault();
                titles = _db.Articles.Where(a => a.Author == user.Email)
                    .Where(a => a.CategoryId == categoryId)
                    .Select(a => a.Title);
            }
            return View(titles);
        }

        public async Task<IActionResult> Others()
        {
            //查询该用户所有的others类别的文章返回给视图
            var user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<string> titles = null;
            if (user != null)
            {
                var categoryId = _db.Categories.Where(c => c.CategoryName == "others")
                    .Select(c => c.Id).FirstOrDefault();
                titles = _db.Articles.Where(a => a.Author == user.Email)
                    .Where(a => a.CategoryId == categoryId)
                    .Select(a => a.Title);
            }
            return View(titles);
        }

        public IActionResult WriteArticle(string cateName,string Title)
        {
            var model = new WriteArticleDto();
            //如果title为空，说明是新建文章，返回一个指定文章类别的模型
            //如果title不为空，则说明是编辑文章，根据title找到文章并返回有效模型
            if (!string.IsNullOrEmpty(Title))
            {
                model = _db.Articles.Where(a => a.Title == Title)
                    .Select(a=>new WriteArticleDto { 
                        Title=a.Title,
                        Category = cateName
                    })
                    .FirstOrDefault();
                var fullpath = Path.Combine(_webHost.WebRootPath, "md\\" 
                    + cateName + "\\"+Title+".md");
                
                var res = new StringBuilder();
                using (var reader = new StreamReader(fullpath)) 
                {
                    string content;
                    while ((content = reader.ReadLine()) != null)
                    {
                        res.Append(content + '\n');
                    }
                }
                model.Content = res.ToString();
            }
            else
            {
                model.Category = cateName;
            }
            return View(model);
        }
        //点击保存
        [HttpPost]
        public async Task<IActionResult> WriteArticle(WriteArticleDto model)
        {
            //根据model中的category来决定存储的文件路径
            var fullPath = Path.Combine(_webHost.WebRootPath,
                "md\\" + model.Category + "\\" + model.Title + ".md");
            //Console.WriteLine(fullPath);
            //先检测md/{category}下有没有这个标题的md文件
            //如果有，直接覆盖
            if (System.IO.File.Exists(fullPath))
            {
                using (var writer = new StreamWriter(fullPath))
                {
                    await writer.WriteAsync(model.Content);
                    await writer.FlushAsync();
                }
            }
            //如果没有，新建一个article存入数据库，写入对应位置
            else
            {
                using (var writer = new StreamWriter(fullPath))
                {
                    await writer.WriteAsync(model.Content);
                    await writer.FlushAsync();
                }

                var article = new Article();
                article.Id = Guid.NewGuid();
                article.Title = model.Title;
                var catagory = _db.Categories.Where(c => c.CategoryName == model.Category).FirstOrDefault();
                article.CategoryId = catagory.Id;
                article.Category = catagory;
                var user = await _userManager.GetUserAsync(HttpContext.User);
                article.Author = user.Email;
                article.URL = fullPath;

                await _db.AddAsync(article);
                await _db.SaveChangesAsync();
            }
            return View(model);
        }
        //点击发布，为了避免用户点了保存又点发布导致重复写入
        //在WriteArticleDto中加入一个保存时间属性用来判定用户是否在短时间内
        //点了保存按钮又点发布。
        [HttpPost]
        public async Task<string> Publish(WriteArticleDto model)
        {
            //通过传进来的model找到数据库中的这篇文章
            //将haspublish改为true
            //记录当前时间为Publish Time

            //最后考虑重复写入的问题
            //
            return "OK";
        }
        //在主页面上点击文章链接后显示
        public IActionResult Show(string title)
        {
            //Console.WriteLine(title);
            //根据title在数据库中查找该article所有信息
            //读取md文件放入content，然后传到页面上
            var article = _db.Articles.Where(a => a.Title == title).FirstOrDefault();
            StringBuilder builder = new StringBuilder();
            string tmp=null;
            var reader = new StreamReader(article.URL);
            while((tmp = reader.ReadLine()) != null)
            {
                //在markdown中，<br>表示换行
                builder.Append(tmp + "<br>");
            }
            Console.WriteLine(builder.ToString());
            ViewBag.Text = builder.ToString();
            return View();
        }
    }
}
