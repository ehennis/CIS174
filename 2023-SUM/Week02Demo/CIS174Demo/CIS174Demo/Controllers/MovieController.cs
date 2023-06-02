using CIS174Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIS174Demo.Controllers
{

    public class MovieController : Controller
    {
        private MovieContext context { get; set; }

        public MovieController(MovieContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            //var movies = context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }

        public IActionResult Add()
        {
            var mv = new Movie();
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.ToList();
            return View("Edit", mv);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.ToList();

            var movie = context.Movies.Where( m => m.MovieId == id).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    //INSERT
                    this.context.Add(movie);
                }
                else
                {
                    this.context.Update(movie);
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Genres = context.Genres.ToList();
                ViewBag.Action = (movie.MovieId == 0) ? "Add" : "Edit";
                return View(movie);
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = this.context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
