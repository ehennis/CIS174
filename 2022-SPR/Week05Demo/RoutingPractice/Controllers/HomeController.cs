﻿using Microsoft.AspNetCore.Mvc;

namespace RoutingPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }

        public IActionResult Privacy()
        {
            return Content("Privacy");
        }

        public IActionResult Display(string id)
        {
            if (id == null)
            {
                return Content("No ID supplied.");
            }
            else
            {
                return Content("ID: " + id);
            }
        }
                
        public IActionResult StaticContent(string num)
        {
            return Content($"Static Content: {num}");
        }
        
        [Route("/")]
        public IActionResult IndexOverride()
        {
            return Content("Index Override!");
        }


    }
}