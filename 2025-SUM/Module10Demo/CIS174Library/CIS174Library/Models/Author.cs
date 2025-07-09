﻿using System.ComponentModel.DataAnnotations;

namespace CIS174Library.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
