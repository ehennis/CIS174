using Microsoft.AspNetCore.Mvc;

namespace CIS174Library.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            int num = HttpContext.Session.GetInt32("num") ?? 0;
            num += 1;
            HttpContext.Session.SetInt32("num", num);

            var options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("username", "evan", options);

            return View();
        }

        public IActionResult Cookie()
        {
            var usrname = Request.Cookies["username"];
            ViewBag.UserName = usrname;

            return View();
        }
    }
}
