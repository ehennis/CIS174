using Microsoft.EntityFrameworkCore;
using CIS174Library.Models;

namespace CIS174Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "Core MVC",
                    Year = 2022
                },
                new Book
                {
                    BookId = 2,
                    Name = "The C++ Programming Language",
                    Year = 2000
                });
        }
    }
}
