﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heyday_Website.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
