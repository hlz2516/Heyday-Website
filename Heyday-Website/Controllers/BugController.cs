using Heyday_Website.Models;
using Heyday_Website.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.ViewModels;
using Microsoft.AspNetCore.Identity;

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
            ViewBag.UserName = HttpContext.User.Identity.Name;
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
                return RedirectToAction("AccountIndex", "Home");
            }
            return View(model);
        }

        public IActionResult BugListOfUser()
        {
            return View();
        }
    }
}
