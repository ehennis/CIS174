using System;
using Xunit;
using Moq;
using Week08.Controllers;
using Week11.Models;
using Week12.Service;
using Microsoft.AspNetCore.Mvc;

namespace Week12Test
{
    public class HomeControllerTest
    {
        private HomeController controller;

        public HomeControllerTest()
        {
            Mock<IBookService> bookService = new Mock<IBookService>();

            bookService.Setup(s => s.GetBook()).Returns(new Book());

            controller = new HomeController(bookService.Object);
        }

        [Fact]
        public void GetBook_HappyPath()
        {
            var iaction = controller.Bookstore();
            ViewResult vr = Assert.IsType<ViewResult>(iaction);
            Book bk = Assert.IsType<Book>(vr.Model);
        }

        [Theory]
        [InlineData("Book Name")]
        [InlineData("Book Two")]
        public void ParameterizedTests(string name)
        {
            Book bk = new Book();
            bk.Title = name;

            Mock<IBookService> bs = new Mock<IBookService>();
            bs.Setup(b => b.GetBook()).Returns(bk);

            HomeController ctrl = new HomeController(bs.Object);
            var iaction = ctrl.Bookstore();
            ViewResult vr = Assert.IsType<ViewResult>(iaction);
            Book bkreturn = Assert.IsType<Book>(vr.Model);
            Assert.Equal(name, bkreturn.Title);
        }
    }
}
