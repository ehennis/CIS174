using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Week11.Models
{
    public class Book
    {
        //public int BookId { get; set; }
        [Key]
        public string ISBN { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
