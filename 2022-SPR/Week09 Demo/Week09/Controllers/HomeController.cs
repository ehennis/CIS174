using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week08.Models;
using Week09.Models;

namespace Week08.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int num = HttpContext.Session.GetInt32("num") ?? 0;
            num += 1;
            HttpContext.Session.SetInt32("num", num);

            var options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("username", "evan", options);

            ViewBag.CustomerName = "John";
            return View();
        }

        public IActionResult Privacy()
        {
            var usrname = Request.Cookies["username"];
            ViewBag.UserName = usrname;

            return View();
        }
        /*
        [HttpPost]
        public IActionResult Add(string description)
        {
            string desc = description;
            return View();
        }
        */
        [HttpPost]
        public IActionResult Add(ToDo task)
        {
            string desc = task.Description;
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
