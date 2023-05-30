using CIS174Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryListTest
{
    [TestClass]
    public class LibraryRepositoryTest
    {

        [TestMethod]
        public void FindBook_Happy()
        {
            var inmemory = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase("Filename=test.db")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            LibraryContext cntx = new LibraryContext(inmemory);

            cntx.Books.Add(new Book() { BookId = 1, Name = "One", Year =1 });
            cntx.Books.Add(new Book() { BookId = 2, Name = "Two", Year = 2 });
            cntx.Books.Add(new Book() { BookId = 3, Name = "Three", Year = 3 });
            cntx.Books.Add(new Book() { BookId = 4, Name = "Four", Year = 4 });
            cntx.SaveChanges();



            LibraryRepository repo = new LibraryRepository(cntx);
            var bk = repo.Find(2);

            Assert.AreEqual(2, bk.BookId);
        }
    }
}
