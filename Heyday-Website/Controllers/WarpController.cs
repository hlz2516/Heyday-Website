using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Controllers
{
    public class WarpController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
