using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week14.Models;

namespace Week14.Controllers
{
    [Authorize]
    public class SecureController : Controller
    {

        public SecureController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Evan()
        {
            return View();
        }
    }
}
