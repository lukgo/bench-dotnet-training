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

    public IEnumerable<Movie> GetAll() => [.. _context.Movie.AsNoTracking()];

    public IEnumerable<Cinema> GetCinemas() => [.. _context.Cinema.AsNoTracking()];

    public IEnumerable<MovieCinema> GetMovieCinemas() => [.. _context.MovieCinema.AsNoTracking()];

    public IEnumerable<Movie>? GetMovieByTitle(string title) =>
        [
            .. _context.Movie.Where(m =>
                m.title != null && m.title.ToLower().Contains(title.ToLower())
            )
        ];

    public IEnumerable<Movie>? GetMovieByGenre(string genre) =>
        [
            .. _context.Movie.Where(m =>
                m.genre != null && m.genre.ToLower().Contains(genre.ToLower())
            )
        ];
}
