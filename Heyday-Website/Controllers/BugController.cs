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

        public IActionResult BugGeneral(int? id)
        {
            if (!id.HasValue || id == 0)
                id = 1;
            var bugs = _db.Bugs.AsEnumerable();
            var bugList = new PagingList<Bug>(bugs,(int)id,10);

            return View(bugList);
        }

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

        public async Task<IActionResult> BugListOfUser()
        {
            var email = (await _userManager.GetUserAsync(HttpContext.User)).Email;
            var bugs =await _db.Bugs.Where(b => b.SubmitterEmail == email).ToListAsync();
            return View(bugs);
        }

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

        public JsonResult GetTitleAndDetail(string bugId)
        {
            var message = _db.Bugs.Where(b => b.Id.ToString() == bugId)
                .Select(b => new { Title = b.Title, Detail = b.Content })
                .FirstOrDefault();
                
            return Json(message);
        }

        public string DeleteMyBug(string bugId)
        {
            var bug = _db.Bugs.Where(b => b.Id.ToString() == bugId).FirstOrDefault();
            _db.Bugs.Remove(bug);
            _db.SaveChanges();
            return "OK";
        }
    }
}
