using CIS174Library.Data;
using CIS174Library.Models;

namespace CIS174Library.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private LibraryContext context;
        public LibraryRepository(LibraryContext cntx)
        {
            context = cntx;
        }
        public List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }
        public List<Book> GetOddBooks()
        {
            return context.Books
                .Where(b => b.BookId % 2 == 1)
                .ToList();
        }

        public Book Find(int id)
        {
            return context.Books.Find(id);
        }

        public void DeleteBook(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }


        public void InsertBook(Book book)
        {
            context.Books.Add(book);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            context.Books.Update(book);
        }
    }
}
