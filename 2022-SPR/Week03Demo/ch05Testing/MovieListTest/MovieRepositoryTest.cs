using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieList.Models;
using MovieList.Repository;

namespace MovieListTest
{
    [TestClass()]
    public class MovieRepositoryTest
    {
        private MovieRepository repository;

        private Mock<DbSet<Movie>> mockMovies;
        private Mock<DbSet<Genre>> mockGenre;


        public MovieRepositoryTest()
        {
            mockMovies = new Mock<DbSet<Movie>>();
            mockGenre = new Mock<DbSet<Genre>>();

            var mockContext = new Mock<MovieContext>();
            mockContext.Setup(m => m.Movies).Returns(mockMovies.Object);
            mockContext.Setup(m => m.Genres).Returns(mockGenre.Object);

            repository = new MovieRepository(mockContext.Object);
        }

        [TestMethod()]
        public void AddMovie_HappyPath()
        {
            Movie mv = new Movie() { MovieId = 1, Name = "Movie 1", Rating = 5, Year = 2022, GenreId = "1", Genre = new Genre() { GenreId = "1", Name = "Genre 1" } };
            repository.InsertMovie(mv);

            mockMovies.Verify(m => m.Add(It.IsAny<Movie>()), Times.Once());
        }

        /*
        [TestMethod()]
        public void GetAllMovies_HappyPath()
        {
            //return this.context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
            Genre tmp = new Genre() { GenreId = "1", Name = "Genre 1" };
            List<Movie> mvList = new List<Movie>()
            {
                new Movie() { MovieId = 1, Name = "Movie 1", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 2, Name = "Movie 2", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 3, Name = "Movie 3", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp },
                new Movie() { MovieId = 4, Name = "Movie 4", Rating = 5, Year = 2022, GenreId = "1", Genre = tmp }
            };
            var data = mvList.AsQueryable();

            mockMovies.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockMovies.As<IQueryable<Movie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockMovies.As<IQueryable<Movie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockMovies.As<IQueryable<Movie>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var movies = repository.GetAllMovies();
            Assert.AreEqual(mvList.Count, movies.Count());
        }
        */

    }
}
