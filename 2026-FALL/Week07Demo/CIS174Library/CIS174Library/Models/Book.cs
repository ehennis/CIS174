using System.ComponentModel.DataAnnotations;

namespace CIS174Library.Models
{
    public class Book
    {
        // EF will instruct the database to automatically generate this value
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1889, 2050, ErrorMessage = "Year must be between 1889 and now.")]
        public int? Year { get; set; }
    }
}
