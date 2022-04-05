using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week11.Models
{
    public class AuthorBio
    {
        public int AuthorBioId { get; set; }
        public int AuthorId { get; set; }
        public DateTime? DOB { get; set; }
        public Author Author { get; set; }

    }
}
