using Microsoft.AspNetCore.Mvc;

namespace CIS174Library.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cookie()
        {
            return View();
        }
    }
}
