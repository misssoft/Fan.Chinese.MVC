using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Fan.Chinese.MVC.Controllers
{
    public class ErrorController: Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "System Error";
            ViewData["Message"] = "Ooooops, Something went wrong in the system.";
            return View();
        }

        [Route("System")]
        public IActionResult System(string message = null)
        {
            ViewData["Title"] = "System Error";

            if (string.IsNullOrEmpty(message))
                ViewData["Message"] = "Ooooops, Something went wrong in the system.";
            else
            {
                ViewData["Message"] = message;
            }
            return View();
        }

        [Route("System/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            ViewData["Title"] = "System Error: " + statusCode.ToString();
            ViewData["Message"] = "Ooooops, Something went wrong in the system";
            return View();
        }

    }
}
