﻿using Heyday_Website.Models;
using Heyday_Website.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly Models.AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BugController(Models.AppDbContext context,UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult BugGeneral(int pageIndex)
        {
            var bugList = new MvcPagingList<AppDbContext, Bug>(_db,10);
            var bugs = bugList.GetPageTableByDesc(pageIndex, b => b.SubmitTime);
            var model = new BugGeneralDto
            {
                Bugs = bugs,
                TotalPage = bugList.TotalPage,
                PageIndex = pageIndex
            };
            ViewBag.Title = "Heyday-Bug总览";
            return View("BugList", model);
        }
        [Authorize]
        public IActionResult BugWrite()
        {
            ViewBag.Title = "Heyday-Bug填写";
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
                ViewBag.Title = "Heyday-Bug填写";
                return View("BugWrite");
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> BugListOfUser()
        {
            var email = (await _userManager.GetUserAsync(HttpContext.User)).Email;
            var bugs =await _db.Bugs.Where(b => b.SubmitterEmail == email).ToListAsync();
            //处理“用户已提交bug列表”的每个Bug的标题
            foreach (var bug in bugs)
            {
                if(bug.Title.Length > 6)
                {
                    bug.Title = bug.Title.Substring(0, 6) + "...";
                }
            }
            ViewBag.Title = "您已提交的Bug列表";
            return View(bugs);
        }
        [Authorize]
        public async Task<IActionResult> EditMySubmitBug()
        {
            var id = Request.Form["bugId"].ToString();
            var bug = _db.Bugs.Where(b => b.Id.ToString() == id).FirstOrDefault();
            bug.Title = Request.Form["bugTitle"].ToString();
            bug.Content = Request.Form["bugDetail"].ToString();
            bug.SubmitTime = Convert.ToDateTime(Request.Form["submitTime"].ToString());
            _db.Bugs.Update(bug);
            await _db.SaveChangesAsync();

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
        public async Task<string> DeleteMyBug(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            _db.Bugs.Remove(bug);
            await _db.SaveChangesAsync();
            return "OK";
        }
        [Authorize(Roles ="Admin,Root")]
        public IActionResult CanTakeOverBugs()
        {
            //检索出状态为待处理和抛回的bug返回给页面
            var bugs = _db.Bugs.Where(b => b.BugState == BugState.pending ||
            b.BugState == BugState.throwback);
            ViewBag.Title = "Heyday-可以接手的Bug列表";
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
        public async Task<IActionResult> BugFactory()
        {
            var email = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Email;
            var receivedBugs = _db.Solutions.Where(s=>s.Solver == email).Select(s => s.Bug);
            foreach (var bug in receivedBugs)
            {
                if (bug.Title.Length > 6)
                {
                    bug.Title = bug.Title.Substring(0, 6) + "...";
                }
            }
            ViewBag.Title = "Heyday-Bug修复";
            return View(receivedBugs);
        }
        [Authorize(Roles ="Admin,Root")]
        public async Task<string> BugSubmit(string bugId,string solution)
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

            await _db.SaveChangesAsync();
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
        public async Task<string> ThrowIt(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (bug != null)
                bug.BugState = BugState.throwback;
            await _db.SaveChangesAsync();
            return "OK";
        }
        [Authorize(Roles = "Admin,Root")]
        public async Task<string> Rejectit(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            if (bug != null)
                bug.BugState = BugState.reject;
            await _db.SaveChangesAsync();
            return "OK";
        }

        public IActionResult BugList()
        {
            var bugList = new MvcPagingList<AppDbContext, Bug>(_db, 10);
            var bugs = bugList.GetPageTableByDesc(1, b => b.SubmitTime);
            var model = new BugGeneralDto
            {
                Bugs = bugs,
                TotalPage = bugList.TotalPage,
                PageIndex = 1
            };
            ViewBag.Title = "Heyday-Bug总览";
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> NewBugWrite(BugWriteDto model)
        {
            if (ModelState.IsValid)
            {
                var email = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Email;
                var bug = new Bug()
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Content = model.Content,
                    SubmitterEmail = email,
                    BugState = BugState.pending,
                    SubmitTime = model.SubmitTime
                };
                await _db.Bugs.AddAsync(bug);
                await _db.SaveChangesAsync();
                ViewBag.IsSubmitted = 1;
                ViewBag.Title = "Heyday-Bug填写";
                return Json(new { result="成功提交"});
            }
            return Json(new { result = "提交失败,请务必填写概述！" });
        }
        //外部option默认选择为all

        public async Task<IActionResult> BugSearch(string searchStr,string option,int pageIndex)
        {
            //如果searchStr为空并且option为all，则直接执行BugGeneral方法
            if ((searchStr == null || searchStr.Equals("") || searchStr == "null") 
                && (option.Equals("null") || option.Equals("all")))
            {
                return RedirectToAction("BugGeneral", new { pageIndex = pageIndex});
            }
            if (searchStr == null || searchStr.Equals("null"))
                searchStr = "";
            BugGeneralDto model = null;
            //先看是查询个人的还是所有
            if (option == "onlyMe")
            {
                //先要知道我是谁
                var email = (await _userManager.FindByNameAsync(HttpContext.User.Identity.Name)).Email;
                //如果搜索字符串为空，不做筛选返回分页模型
                var bugs = _db.Bugs.Where(b => b.SubmitterEmail == email)
                    .Where(b=>b.Title.Contains(searchStr) || b.Content.Contains(searchStr))
                    .AsEnumerable();
                  var pagedBugs  = bugs.OrderByDescending(b=>b.SubmitTime)
                    .Skip((pageIndex - 1) * 10).Take(10);
                var totalPages = (int)Math.Ceiling(bugs.Count() / (double)10);
                model = new BugGeneralDto
                {
                    Bugs = pagedBugs,
                    PageIndex = pageIndex,
                    TotalPage = totalPages
                };
            }
            else if (option == "all")
            {
                //筛选出所有带有searchStr的bug,返回对应的分页模型
                var bugs = _db.Bugs.Where(b => b.Title.Contains(searchStr) || b.Content.Contains(searchStr))
                    .AsEnumerable();
                var pagedBugs = bugs.OrderByDescending(b => b.SubmitTime)
                    .Skip((pageIndex - 1) * 10).Take(10);
                var totalPages = (int)Math.Ceiling(bugs.Count() / (double)10);
                model = new BugGeneralDto
                {
                    Bugs = pagedBugs,
                    PageIndex = pageIndex,
                    TotalPage = totalPages
                };
            }
            //用bugTest的视图，但带的是这里的model
            return View("BugList", model);
        }

        public async Task EditBug(BugEditDto model)
        {
            var user =await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var thisBug = _db.Bugs.Where(b => b.SubmitterEmail == user.Email)
                .Where(b=>b.Id == model.Id)
                .FirstOrDefault();
            if(thisBug != null)
            {
                thisBug.Title = model.Title;
                thisBug.Content = model.Content;
                thisBug.SubmitTime = model.SubmitTime;
                _db.Update(thisBug);
                await _db.SaveChangesAsync();
            }
        }
    }
}
