using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Week10.Models
{
    public class Movie
    {
        [MovieFirstName]
        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(30)]
        public string Name { get; set; }

        [Range(1,5, ErrorMessage = "Please enter a rating between 1 and 5")]
        public int Rating { get; set; }
    }
}
