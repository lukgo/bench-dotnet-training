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

    public IEnumerable<Movie.MovieWithAverageScore> GetAll()
    {
        return
        [
            .. _context.Movie.Select(movie => new Movie.MovieWithAverageScore(
                movie,
                GetAverageMovieScore(movie.id, _context)
            ))
        ];
    }

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

    public Movie.MovieWithAverageScore GetMovieDetails(int id)
    {
        var movieDetails = _context.Movie.AsNoTracking().FirstOrDefault(m => m.id == id);
        return new Movie.MovieWithAverageScore(movieDetails, GetAverageMovieScore(id, _context));
    }

    private static double GetAverageMovieScore(int id, MovieContext context)
    {
        var movieReviews = context.MovieReview.Where(review => review.movieId == id);
        if (!movieReviews.Any())
            return 0;
        return movieReviews.Select(r => (double)r.score).Average();
    }

    public IEnumerable<Cinema> GetCinemasWithMovie(int id) =>
        _context.Cinema.Include(c => c.MovieCinema.Where(mc => mc.movieId == id));
}
