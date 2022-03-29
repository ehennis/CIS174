using MovieList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Genre> GetAllGenres();
        Movie Find(int id);
        void Save();
        void InsertMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
