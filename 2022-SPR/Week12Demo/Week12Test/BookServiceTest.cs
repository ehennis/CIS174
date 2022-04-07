using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Week11.Models;
using Week12.Service;
using Week12.Repository;

namespace Week12Test
{
    public class BookServiceTest
    {
        private BookService service;

        public BookServiceTest()
        {
            Mock<IBookRepository> repo = new Mock<IBookRepository>();
            repo.Setup(r => r.GetBook()).Returns(new Book());


            service = new BookService(repo.Object);
        }

        [Fact]
        public void GetBook_HappyPath()
        {
            var book = service.GetBook();
            Book bk = Assert.IsType<Book>(book);
        }
    }
}
