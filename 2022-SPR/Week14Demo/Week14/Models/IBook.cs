using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week13.Models
{
    public interface IBook
    {
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }        
    }
}
