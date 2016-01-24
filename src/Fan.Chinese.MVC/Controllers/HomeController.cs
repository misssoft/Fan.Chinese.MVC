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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("Error/Status/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            ViewData["Message"] = statusCode.ToString();
            return View();
        }

        public IActionResult ErrorPage()
        {
            ViewData["Message"] = "Ooooops";
            return View();
        }

        public IActionResult NotFoundPage()
        {
            ViewData["Message"] = "Haha";
            return View();
        }
    }
}
