using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieList.Models;
using MovieList.Repository;

namespace MovieListTest
{
    [TestClass()]
    public class MovieRepositoryInMemoryTest
    {
        private MovieRepository repository;


        public MovieRepositoryInMemoryTest()
        {
            var inmemory = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase("Filename=test.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            MovieContext context = new MovieContext(inmemory);
            repository = new MovieRepository(context);

            // Load Data
            Genre tmp = new Genre() { GenreId = "1", Name = "Genre 1" };
            List<Movie> mvList = new List<Movie>()
            {
                new Movie() { MovieId = 1, Name = "Movie 1", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 2, Name = "Movie 2", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 3, Name = "Movie 3", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 4, Name = "Movie 4", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp }
            };
            context.Genres.Add(tmp);
            mvList.ForEach(mv => context.Movies.Add(mv));
            context.SaveChanges();
        }

        [TestMethod()]
        public void GetAllMovies_HappyPath()
        {
            //return this.context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            var movies = repository.GetAllMovies();
            Assert.AreEqual(4, movies.Count());            
        }



        

    }
}
