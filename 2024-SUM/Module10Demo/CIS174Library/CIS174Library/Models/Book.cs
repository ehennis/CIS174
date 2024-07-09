using System.ComponentModel.DataAnnotations;

namespace CIS174Library.Models
{
    public class Book
    {
        // EF will instruct the database to automatically generate this value
        public int BookId { get; set; }

        public string? Name { get; set; }

        public int? Year { get; set; }
    }
}
