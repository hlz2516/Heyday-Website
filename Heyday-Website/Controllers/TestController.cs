using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            ViewBag.Text = "a\nb";
            return View();
        }
        [HttpPost]
        public IActionResult Test(IFormCollection form)
        {
            
            return View();
        }

        public void Asynchronoustesting()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
