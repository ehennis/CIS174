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

        // Step 2
        private readonly LibraryContext _cntx;
        //private ILibraryRepository libraryRepository;

        // Step 2
        public HomeController(ILogger<HomeController> logger, LibraryContext cntx)
        {
            _logger = logger;
            _cntx = cntx;
        }
        //public HomeController(ILogger<HomeController> logger, ILibraryRepository repo)
        //{
        //    _logger = logger;
        //    libraryRepository = repo;
        //}

        public IActionResult Index()
        {
            ViewBag.Name = "Student";

            // Step 2
            List<Book> books = _cntx.Books.ToList();
            //List<Book> books = libraryRepository.GetAllBooks();

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}