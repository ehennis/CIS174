using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week14.Models;

namespace Week11.Models
{
    public class BookstoreContext: IdentityDbContext<User> // DbContext
    {
        //public BookstoreContext() : base() { }
        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Remove cascading deletes with Genre
            modelBuilder.Entity<Book>().HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .OnDelete(DeleteBehavior.Restrict);

            //Seed Initial Data
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "Pop", Name = "Pop" },
                new Genre { GenreId = "History", Name = "History" },
                new Genre { GenreId = "Novel", Name = "Novel" }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, ISBN = "8675309", Title = "Jenny", GenreId = "Pop", Price = 10.00 },
                new Book { BookId = 2, ISBN = "1548547298", Title = "The Hobbit", GenreId = "History", Price = 20.00 },
                new Book { BookId = 3, ISBN = "555", Title = "Harry Potter", GenreId = "Novel", Price = 9.57 }
                );
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, FirstName = "Michelle", LastName = "Alexander" },
                new Author { AuthorId = 2, FirstName = "Tommy", LastName = "TuTone" },
                new Author { AuthorId = 3, FirstName = "Seth", LastName = "Grahame-Smith" }
                );
        }

    }
}
