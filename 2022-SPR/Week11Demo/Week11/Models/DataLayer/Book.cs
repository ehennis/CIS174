using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Week11.Models.DataLayer
{
    [Index(nameof(GenreId), Name = "IX_Books_GenreId")]
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        [Column("ISBN")]
        public string Isbn { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        public double Price { get; set; }
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(10)]
        public string GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Books")]
        public virtual Genre Genre { get; set; }
        [InverseProperty(nameof(BookAuthor.Book))]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
