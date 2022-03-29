using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;
using MovieList.Repository;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        //private MovieContext context { get; set; }

        private IMovieRepository movieRepository;

        //public HomeController(MovieContext ctx)
        public HomeController(IMovieRepository repository)
        {
            //context = ctx;
            this.movieRepository = repository;
        }

        public IActionResult Index()
        {
            //var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            var movies = this.movieRepository.GetAllMovies();
            return View(movies);
        }
    }
}