using Microsoft.EntityFrameworkCore;
using MovieHub.Data;
using MovieHub.Models;

namespace MovieHub.Services;

public class MovieService
{
    private readonly MovieContext _context;

    public MovieService(MovieContext context)
    {
        _context = context;
    }

    // get list of movies

    public IEnumerable<Movie> GetAll() => _context.Movie;

    public IEnumerable<Movie>? GetMoviesByTitle(string title) =>
        [
            .. _context.Movie.Where(m =>
                m.title != null && m.title.ToLower().Contains(title.ToLower())
            )
        ];

    public IEnumerable<Movie>? GetMoviesByGenre(string genre) =>
        [
            .. _context.Movie.Where(m =>
                m.genre != null && m.genre.ToLower().Contains(genre.ToLower())
            )
        ];

    // movie details

    public Movie GetMovieDetails(int id) =>
        _context.Movie.AsNoTracking().FirstOrDefault(m => m.id == id);

    public IEnumerable<Cinema> GetCinemasWithMovie(int id) =>
        _context.Cinema.Include(c => c.MovieCinema.Where(mc => mc.movieId == id));
}
