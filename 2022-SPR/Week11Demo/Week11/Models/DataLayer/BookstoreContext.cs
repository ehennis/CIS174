using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Week11.Models.DataLayer
{
    public partial class BookstoreContext : DbContext
    {
        public BookstoreContext()
        {
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=BookstoreContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName).HasDefaultValueSql("(N'')");

                entity.Property(e => e.LastName).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.GenreId).HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
