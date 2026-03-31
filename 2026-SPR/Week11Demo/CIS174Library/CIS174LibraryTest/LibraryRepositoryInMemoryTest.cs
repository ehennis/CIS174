using CIS174Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS174LibraryTest
{
    [TestClass]
    public class LibraryRepositoryInMemoryTest
    {
        DbContextOptions<LibraryContext> inmemory;

        public LibraryRepositoryInMemoryTest()
        {
            inmemory = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Filename=test.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        [TestMethod]
        public void GetAllBooks_HappyPath()
        {

            LibraryContext cntx = new LibraryContext(inmemory);
            cntx.Books.Add(new Book() { Name = "In Memory", BookId = 1, Year = 1981 });
            cntx.Books.Add(new Book() { Name = "In Memory2", BookId = 2, Year = 2000 });
            cntx.SaveChanges();


            LibraryRepository repo = new LibraryRepository(cntx);
            var books = repo.GetAllBooks();

            Assert.AreEqual(2, books.Count());
        }

        [TestMethod]
        public void GetOddBooks_HappyPath()
        {
            var inmemory = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Filename=test2.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            LibraryContext cntx = new LibraryContext(inmemory);
            cntx.Books.Add(new Book() { Name = "In Memory", BookId = 1, Year = 1981 });
            cntx.Books.Add(new Book() { Name = "In Memory2", BookId = 2, Year = 2000 });
            cntx.Books.Add(new Book() { Name = "In Memory3", BookId = 3, Year = 1981 });
            cntx.Books.Add(new Book() { Name = "In Memory4", BookId = 4, Year = 2000 });
            cntx.SaveChanges();


            LibraryRepository repo = new LibraryRepository(cntx);
            var books = repo.GetOddBooks();

            Assert.AreEqual(2, books.Count());
            Assert.AreEqual(1, books[0].BookId);
            Assert.AreEqual(3, books[1].BookId);
        }

    }
}
