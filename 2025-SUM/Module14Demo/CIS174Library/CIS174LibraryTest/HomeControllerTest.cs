using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CIS174LibraryTest
{
    [TestClass]
    public class HomeControllerTest
    {

        //public IActionResult Index()
        //{
        //    ViewBag.Name = "Student";
        //
        //    List<Book> books = libraryRepository.GetAllBooks();
        //    return View(books);
        //}

        [TestMethod]
        public void Index_Happy()
        {
            // Arrange
            var logger = new Mock<ILogger<HomeController>>();
            var lrMock = new Mock<ILibraryRepository>();
            List<Book> lst = new List<Book>()
            {
                new Book() { BookId = 1, Name = "First Book", Year = 2021},
                new Book() { BookId = 2, Name = "Second Book", Year = 2022}
            };
            lrMock.Setup(r => r.GetAllBooks()).Returns(lst);

            HomeController ctrl = new HomeController(logger.Object, lrMock.Object);

            // Action
            var result = ctrl.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var vr = result as ViewResult;
            Assert.IsInstanceOfType(vr.Model, typeof(List<Book>));
            var mdl = vr.Model as List<Book>;
            Assert.AreEqual(2, mdl.Count());

        }
    }
}
