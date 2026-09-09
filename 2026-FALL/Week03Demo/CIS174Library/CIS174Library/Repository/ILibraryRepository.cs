using CIS174Library.Models;

namespace CIS174Library.Repository
{
    public interface ILibraryRepository
    {
        List<Book> GetAllBooks();
        Book Find(int id);
        void Save();
        void InsertBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
    }
}
