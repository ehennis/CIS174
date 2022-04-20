using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Week11.Models;
using Week12.Service;
using Week12.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Week08.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _service;

        public HomeController(IBookService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Home()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
