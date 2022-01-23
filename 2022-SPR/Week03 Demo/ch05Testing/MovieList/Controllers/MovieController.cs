using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using MovieList.Repository;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        //private MovieContext context { get; set; }
        private IMovieRepository movieRepository;

        //public MovieController(MovieContext ctx)
        public MovieController(IMovieRepository repository)
        {
            //context = ctx
            this.movieRepository = repository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Genres = this.movieRepository.GetAllGenres();
            return View("Edit", new Movie());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            ViewBag.Genres = this.movieRepository.GetAllGenres();
            //var movie = context.Movies.Find(id);
            var movie = this.movieRepository.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    //context.Movies.Add(movie);
                    this.movieRepository.InsertMovie(movie);
                }
                else
                {
                    //context.Movies.Update(movie);
                    this.movieRepository.UpdateMovie(movie);
                }
                //context.SaveChanges();
                this.movieRepository.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add": "Edit";
                //ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
                ViewBag.Genres = this.movieRepository.GetAllGenres();
                return View(movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var movie = context.Movies.Find(id);
            var movie = this.movieRepository.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            //context.Movies.Remove(movie);
            //context.SaveChanges();
            this.movieRepository.DeleteMovie(movie);
            return RedirectToAction("Index", "Home");
        }
    }
}