using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieList.Controllers;
using MovieList.Models;
using MovieList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTest
{
    [TestClass()]
    public class MovieControllerTest
    {
        private MovieController controller;
        private Mock<IMovieRepository> repository;
        private Movie movie;

        public MovieControllerTest()
        {
            repository = new Mock<IMovieRepository>();

            //this.movieRepository.InsertMovie(movie);
            repository.Setup(r => r.InsertMovie(It.IsAny<Movie>()));
            repository.Setup(r => r.UpdateMovie(It.IsAny<Movie>()));
            //this.movieRepository.Save();
            repository.Setup(r => r.Save());


            controller = new MovieController(repository.Object);

        }

        [TestMethod()]
        public void Edit_AddMovie()
        {
            movie = new Movie();
            movie.MovieId = 0;

            controller.Edit(movie);

            repository.Verify(r => r.InsertMovie(It.IsAny<Movie>()), Times.Once());
        }

        [TestMethod()]
        public void Edit_EditMovie()
        {
            movie = new Movie();
            movie.MovieId = 10;

            controller.Edit(movie);

            repository.Verify(r => r.UpdateMovie(It.IsAny<Movie>()), Times.Once());
        }

        [TestMethod()]
        public void Edit_InvalidState()
        {
            //Make state invalid
        }

        //public MovieController(IMovieRepository repository)
        /*
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
        */
    }
}
