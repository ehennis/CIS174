using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week11.Models;
using Week12.Repository;

namespace Week12.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public Book GetBook()
        {
            return _repo.GetBook();
        }
    }
}
