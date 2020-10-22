using Heyday_Website.Models;
using Heyday_Website.ViewModels;
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
        private AppDbContext _db;
        private IWebHostEnvironment _webHost;
        private UserManager<ApplicationUser> _userManager;

        public ArticleController(Models.AppDbContext context,
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
        [Authorize(Roles ="Admin,Root")]
        public IActionResult Index()
        {
            return View();
        }
        //get请求:
        //新建文章：article/writearticle/?cateName="intro"&title=""
        //编辑文章：article/writearticle/?cateName="intro"&title="XXX"
        [Authorize(Roles = "Admin,Root")]
        public async Task<IActionResult> Intro()
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
        [Authorize(Roles = "Admin,Root")]
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
        [Authorize(Roles = "Admin,Root")]
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
        [Authorize(Roles = "Admin,Root")]
        public IActionResult WriteArticle(string cateName,string Title)
        {
            var model = new WriteArticleDto();
            //如果title为空，说明是新建文章，返回一个指定id和文章类别的模型
            //如果title不为空，则说明是编辑文章，根据title找到文章并返回有效模型
            if (!string.IsNullOrEmpty(Title))
            {
                model = _db.Articles.Where(a => a.Title == Title)
                    .Select(a=>new WriteArticleDto { 
                        Id = a.Id,
                        Title=a.Title,
                        Category = cateName
                    })
                    .FirstOrDefault();
                var fullpath = Path.Combine(_webHost.WebRootPath, "md\\" 
                    + cateName + "\\"+model.Id+".md");
                
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
                model.Id = Guid.NewGuid();
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
                "md\\" + model.Category + "\\" + model.Id + ".md");
            //Console.WriteLine(fullPath);
            //如果没有这个md文件，新建一个article存入数据库，写入对应位置
            if (!System.IO.File.Exists(fullPath))
            {
                var article = new Article();
                article.Id = model.Id;
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
            using (var writer = new StreamWriter(fullPath))
            {
                await writer.WriteAsync(model.Content);
                await writer.FlushAsync();
            }
            return View(model);
        }
        //点击发布，为了避免用户点了保存又点发布导致重复写入
        //在WriteArticleDto中加入一个保存时间属性用来判定用户是否在短时间内
        //点了保存按钮又点发布。
        [HttpPost]
        public async Task<string> Publish(WriteArticleDto model)
        {
            var now = DateTime.Now;
            //先根据Model里的id从数据库中找文章，
            var article = _db.Articles.Find(model.Id);
            //如果没找到，说明这是第一次保存（新建文章且没有按过保存），直接调用上一个方法
            if (article == null)
            {
                await WriteArticle(model);
            }
            //如果找到了，说明之前保存过了，需要比较两个时间来决定是否再次写入md
            else
            {
                //Console.WriteLine("now:" + now);
                //Console.WriteLine("save time:" + model.SaveTime);
                TimeSpan saves = new TimeSpan(model.SaveTime.Ticks);
                TimeSpan nows = new TimeSpan(now.Ticks);
                TimeSpan diff = saves.Subtract(nows).Duration();
                //Console.WriteLine(diff.TotalSeconds);
                if(diff.TotalSeconds > 5.0)
                {
                    await WriteArticle(model);
                }
            }
            //无论找没找到，都要更新数据库(经过上面的操作，能保证再次根据Id一定能找到文章),并传回一个时间作为savetime
            var _article = _db.Articles.Find(model.Id);
            _article.HasPublished = true;
            _article.PublishTime = now;
            _db.Articles.Update(_article);
            _db.SaveChanges();
            return now.ToString();
        }
        //在主页面上点击文章链接后显示,谁都可以查看
        public async Task<IActionResult> Show(string title)
        {
            //Console.WriteLine(title);
            //根据title在数据库中查找该article所有信息
            //封装Model返回页面
            var article = _db.Articles.Where(a => a.Title == title).FirstOrDefault();
            var authorName = (await _userManager.FindByEmailAsync(article.Author)).UserName;
            var model = new ShowArticle()
            {
                Title = article.Title,
                AuthorName = authorName,
                PublishTime = article.PublishTime
            };
            StringBuilder builder = new StringBuilder();
            string tmp=null;
            using (var reader = new StreamReader(article.URL))
            {
                while ((tmp = reader.ReadLine()) != null)
                {
                    //之所以加入\\n是因为这里的字符串是传给js，为了不让js中直接翻译换行，所以对\进行转义
                    builder.Append(tmp + "\\n");
                }
            }
            //Console.WriteLine(builder.ToString());
            model.Content = builder.ToString();
            return View(model);
        }
        [Authorize(Roles = "Admin,Root")]
        public async Task<IActionResult> Delete(string title)
        {
            var thisArt = _db.Articles.Where(a => a.Title == title).FirstOrDefault();
            var thisCate = _db.Categories.Where(c => c.Id == thisArt.CategoryId)
                .Select(c=>c.CategoryName).FirstOrDefault();
            try
            {
                System.IO.File.Delete(thisArt.URL);
            }
            catch (Exception)
            {

                throw;
            }
            _db.Articles.Remove(thisArt);
            await _db.SaveChangesAsync();
            return RedirectToAction(thisCate);
        }
    }
}
