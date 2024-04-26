using MovieHub.Models;
using MovieHub.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieHub.Services;

public class MovieService
{
	private readonly MovieContext _context;

	public MovieService(MovieContext context)
	{
			_context = context;
	}

	public IEnumerable<Movie> GetAll()
	{
			return [.. _context.Movie.AsNoTracking()];
	}

	public Movie? GetByTitle(string title)
	{
			return _context.Movie
					.Include(p => p.MovieCinema)
					.Include(p => p.MovieReviews)
					.AsNoTracking()
					.SingleOrDefault(p => p.Title == title);
	}
}