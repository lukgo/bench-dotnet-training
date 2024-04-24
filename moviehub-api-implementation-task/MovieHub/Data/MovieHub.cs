using Microsoft.EntityFrameworkCore;
using MovieHub.Models;

namespace MovieHub.Data;

public class MovieContext : DbContext
{
    public MovieContext (DbContextOptions<MovieContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movie => Set<Movie>();
    public DbSet<MovieReview> MovieReview => Set<MovieReview>();
    public DbSet<MovieCinema> MovieCinema => Set<MovieCinema>();
    public DbSet<Cinema> Cinema => Set<Cinema>();

}