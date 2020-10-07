using Heyday_Website.Models;
using Heyday_Website.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Heyday_Website.Controllers
{
    public class BugController:Controller
    {
        private Models.AppContext _db;
        private UserManager<ApplicationUser> _userManager;

        public BugController(Models.AppContext context,UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult BugGeneral(int? id)
        {
            if (!id.HasValue || id == 0)
                id = 1;
            var bugs = _db.Bugs.AsEnumerable();
            var bugList = new PagingList<Bug>(bugs,(int)id,10);

            return View(bugList);
        }
        [Authorize]
        public IActionResult BugWrite()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BugWrite(BugWriteDto model)
        {
            if (ModelState.IsValid)
            {
                var email = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Email;
                var bug = new Bug()
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Content = model.Content,
                    SubmitterEmail =email,
                    BugState = BugState.pending,
                    SubmitTime = model.SubmitTime
                };
                await _db.Bugs.AddAsync(bug);
                await _db.SaveChangesAsync();
                ViewBag.IsSubmitted = 1;
                return View("BugWrite");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> BugListOfUser()
        {
            var email = (await _userManager.GetUserAsync(HttpContext.User)).Email;
            var bugs =await _db.Bugs.Where(b => b.SubmitterEmail == email).ToListAsync();
            return View(bugs);
        }
        [Authorize]
        public IActionResult EditMySubmitBug()
        {
            var id = Request.Form["bugId"].ToString();
            var bug = _db.Bugs.Where(b => b.Id.ToString() == id).FirstOrDefault();
            bug.Title = Request.Form["bugTitle"].ToString();
            bug.Content = Request.Form["bugDetail"].ToString();
            bug.SubmitTime = Convert.ToDateTime(Request.Form["submitTime"].ToString());
            _db.Bugs.Update(bug);
            _db.SaveChanges();

            return RedirectToAction("BugListOfUser");
        }
        [Authorize]
        public JsonResult GetTitleAndDetail(string bugId)
        {
            var message = _db.Bugs.Where(b => b.Id.ToString() == bugId)
                .Select(b => new { Title = b.Title, Detail = b.Content,State = (int)b.BugState })
                .FirstOrDefault();
                
            return Json(message);
        }
        [Authorize(Roles ="Admin,Root")]
        public JsonResult GetTitleDetailAndSolution(string bugId)
        {
            var message = _db.Solutions.Where(s => s.BugId.ToString() == bugId)
                .Select(s => new { Title = s.Bug.Title, Detail = s.Bug.Content, 
                    Solution = s.Context,State = (int)s.Bug.BugState })
                .FirstOrDefault();
            return Json(message);
        }
        [Authorize]
        public string DeleteMyBug(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            _db.Bugs.Remove(bug);
            _db.SaveChanges();
            return "OK";
        }
        [Authorize(Roles ="Admin,Root")]
        public IActionResult CanTakeOverBugs()
        {
            //检索出状态为待处理和抛回的bug返回给页面
            var bugs = _db.Bugs.Where(b => b.BugState == BugState.pending ||
            b.BugState == BugState.throwback);
            return View(bugs);
        }
        [Authorize(Roles ="Admin,Root")]
        public async Task<string> AddToFactory(string bugId)
        {
            //new一个solution加入到solutions表中
            var solverEmail = (await _userManager.GetUserAsync(HttpContext.User)).Email;
            var sln = new Solution()
            {
                Id = Guid.NewGuid(),
                BugId = new Guid(bugId),
                Solver = solverEmail
            };
            await _db.Solutions.AddAsync(sln);
            //找到该bug，将其状态改为处理中
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (bug != null)
                bug.BugState = BugState.processing;
            _db.Bugs.Update(bug);
           await  _db.SaveChangesAsync();
            return "OK";
        }
        [Authorize(Roles = "Admin,Root")]
        public IActionResult BugFactory()
        {
            var receivedBugs = _db.Solutions.Select(s => s.Bug);
            return View(receivedBugs);
        }
        [Authorize(Roles ="Admin,Root")]
        public string BugSubmit(string bugId,string solution)
        {
            //更新solution
            var thisSln = _db.Solutions.Where(s => s.BugId.ToString() == bugId).FirstOrDefault();
            if (thisSln != null)
                thisSln.Context = solution;
            _db.Solutions.Update(thisSln);
            //改变bug状态为已交付
            var thisBug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (thisBug != null)
                thisBug.BugState = BugState.delivered;
            _db.Bugs.Update(thisBug);

            _db.SaveChanges();
            return "OK";
        }
        [Authorize]
        public void ChangeStateToSolved(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (bug != null)
            {
                bug.BugState = BugState.solved;
                //获取该Bug所有信息并写入txt
                var solution = _db.Solutions.Where(s => s.BugId.ToString() == bugId).FirstOrDefault();
                var fullPath = System.IO.Path.Combine(RootPathHelper.hostEnvironment.ContentRootPath, @"Logs\SolvedBugs.txt");
                //Console.WriteLine(fullPath);
                FileStream stream = null;
                if (!System.IO.File.Exists(fullPath))
                    stream = System.IO.File.Create(fullPath);
                else stream = System.IO.File.Open(fullPath, FileMode.Append);
                using (var sw = new StreamWriter(stream))
                {
                    sw.WriteLine("==============================");
                    sw.WriteLine("bug message:");
                    sw.WriteLine("id:" + bug.Id.ToString());
                    sw.WriteLine("title:" + bug.Title);
                    sw.WriteLine("content:" + bug.Content);
                    sw.WriteLine("submitter email:" + bug.SubmitterEmail);
                    sw.WriteLine("submit time:" + bug.SubmitTime);
                    sw.WriteLine("solution message:");
                    sw.WriteLine("id:" + solution.Id);
                    sw.WriteLine("solver email:" + solution.Solver);
                    sw.WriteLine("content:" + solution.Context);
                    sw.WriteLine("==============================");
                    sw.Flush();
                }
            }
            _db.SaveChanges();
        }
        [Authorize(Roles ="Admin,Root")]
        public string ThrowIt(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (bug != null)
                bug.BugState = BugState.throwback;
            _db.SaveChanges();
            return "OK";
        }
    }
}
