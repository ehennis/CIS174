using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week11.Models;

namespace Week12.Repository
{
    public class BookRepository : IBookRepository
    {
        private BookstoreContext _context;

        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public Book GetBook()
        {
            return _context.Books.Where( b => b.BookId == 1).FirstOrDefault();
        }
    }
}
