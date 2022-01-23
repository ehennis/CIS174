using Microsoft.EntityFrameworkCore;
using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private MovieContext context;
        public MovieRepository(MovieContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return this.context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return context.Genres.OrderBy(g => g.Name).ToList();
        }

        public Movie Find(int id)
        {
            return context.Movies.Find(id);
        }

        public void InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            context.Movies.Update(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
