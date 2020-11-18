using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Heyday_Website.ViewModels;

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
        public IActionResult PostModel()
        {
            return View();
        }

        [HttpPost]
        public void PostModel(TestViewModel model)
        {
            
        }

        public IActionResult TestLocalStorage()
        {
            return View();
        }

        public IActionResult TestMultiAspRoute()
        {
            return View();
        }
        public IActionResult MultiAspRoute(string name,int age)
        {
            return View();
        }
    }
}
