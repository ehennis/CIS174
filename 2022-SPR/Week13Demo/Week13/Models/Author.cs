using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Week11.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(200)]
        [Remote("CheckAuthor", "Validation", "", AdditionalFields = "FirstName, Operation")]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
