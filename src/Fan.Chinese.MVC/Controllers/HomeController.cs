using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Fan.Chinese.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            ViewData["Message"] = "This is the home page";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About";
            ViewData["Message"] = "The web site is about GCSE Chinese";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            ViewData["Message"] = "Contact me";
            return View();
        }

        [Route("Error/Status/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            ViewData["Title"] = "System Error: " + statusCode.ToString();
            ViewData["Message"] = "Ooooops, Something went wrong in the system";
            return View();
        }

        public IActionResult ErrorPage()
        {
            ViewData["Title"] = "System Error";
            ViewData["Message"] = "Ooooops, Something went wrong in the system.";
            return View();
        }

        public IActionResult NotFoundPage()
        {
            ViewData["Title"] = "Page Not Found";
            ViewData["Message"] = "Haha, your page seems not exist, please check the URL.";
            return View();
        }
    }
}
