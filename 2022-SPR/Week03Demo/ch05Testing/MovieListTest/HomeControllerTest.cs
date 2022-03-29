using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieList.Models;
using MovieList.Repository;
using MovieList.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MovieListTest
{
    [TestClass()]
    public class HomeControllerTest
    {
        // Controller to test
        private HomeController controller;
        private Mock<IMovieRepository> fakeRepository;

        // Faked Data
        private IList<Movie> mvList;

        public HomeControllerTest()
        {
            // *******
            // Arrange
            // *******

            // Create fake data
            Genre tmp = new Genre() { GenreId = "1", Name = "Fake Genre" };
            mvList = new List<Movie>();
            mvList.Add(new Movie() { MovieId = 1, Name = "Test 1", Rating = 1, GenreId = "1", Genre = tmp, Year = 2022 });
            mvList.Add(new Movie() { MovieId = 2, Name = "Test 2", Rating = 1, GenreId = "1", Genre = tmp, Year = 2022 });
            mvList.Add(new Movie() { MovieId = 3, Name = "Test 3", Rating = 1, GenreId = "1", Genre = tmp, Year = 2022 });

            // Create fake repository
            fakeRepository = new Mock<IMovieRepository>();
            // Create a "moq" that will return our local data instead of hitting the database
            fakeRepository.Setup(r => r.GetAllMovies()).Returns(mvList);

            // Create controller with faked repository
            controller = new HomeController(fakeRepository.Object);
        }

        [TestMethod()]
        public void IndexReturnsMovies()
        {
            // ***
            // Act
            // ***
            var result = controller.Index();

            // ******
            // Assert
            // ******
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult vr = result as ViewResult;
            var mdl = vr.ViewData.Model;
            Assert.IsInstanceOfType(mdl, typeof(List<Movie>));
            var data = mdl as List<Movie>;
            Assert.AreEqual(mvList.Count, data.Count);            
        }
    }
}
