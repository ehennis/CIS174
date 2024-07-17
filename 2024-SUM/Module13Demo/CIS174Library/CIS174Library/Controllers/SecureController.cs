using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS174Library.Models;

namespace CIS174Library.Controllers
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
