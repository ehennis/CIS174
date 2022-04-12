using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week11.Models;

namespace Week12.Repository
{
    public interface IBookRepository
    {
        public Book GetBook();
    }
}
