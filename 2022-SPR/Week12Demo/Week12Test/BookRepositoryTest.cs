using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11.Models;
using Week12.Repository;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Week12Test
{
    public class BookRepositoryTest
    {
        private BookRepository repo;

        public BookRepositoryTest()
        {
            DbContextOptions<BookstoreContext> options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase("DbName").Options;

            BookstoreContext context = new BookstoreContext(options);
            context.Books.Add(new Book() { BookId = 1, Title = "Book One", ISBN = "10" });
            context.Books.Add(new Book() { BookId = 2, Title = "Book Two", ISBN = "11"   });
            context.Books.Add(new Book() { BookId = 3, Title = "Book Three", ISBN = "12" });
            context.SaveChanges();

            repo = new BookRepository(context);

        }

        [Fact]
        public void GetBook_HappyPath()
        {
            var bk = repo.GetBook();
            Assert.NotNull(bk);
            Assert.Equal(1, bk.BookId);
        }
    }
}
