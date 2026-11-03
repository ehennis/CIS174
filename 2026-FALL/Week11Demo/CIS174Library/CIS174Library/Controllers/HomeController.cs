using CIS174Library.Data;
using CIS174Library.Models;
using CIS174Library.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CIS174Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILibraryRepository libraryRepository;

        public HomeController(ILogger<HomeController> logger, ILibraryRepository repo)
        {
            _logger = logger;
            libraryRepository = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Name = "Student";

            List<Book> books = libraryRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult OtherPrivacy()
        {
            return View("Privacy");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}