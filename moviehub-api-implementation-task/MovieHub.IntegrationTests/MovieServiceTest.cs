using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieHub.Data;
using MovieHub.Models;
using MovieHub.Services;

namespace MovieHub.IntegrationTests;

#region UsingTheFixture
public class MovieServiceTest
{
    public MovieServiceTest()
    {
        var builder = new DbContextOptionsBuilder<MovieContext>();
        var _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        builder.UseSqlite(_connection);
        context = new MovieContext(builder.Options);
        context.Database.EnsureCreated();
    }

    public MovieContext context;

#endregion

    #region GetMovieByTitle
    [Fact]
    public void TestGetMovieByTitle()
    {
        const string MOVIE_TITLE = "Star Wars: The Phantom Menace (Episode I)";
        var movie = TestHelpers.CreateMovie(
            releaseDate: new DateOnly(1999, 5, 19),
            title: MOVIE_TITLE
        );

        context.Movie.Add(movie);
        context.SaveChanges();
        var service = new MovieService(context);

        var movies = service?.GetMoviesByTitle(MOVIE_TITLE);

        Assert.Collection(movies, b => Assert.Equal(MOVIE_TITLE, b.title));
    }
    #endregion


    #region GetMovieByGenre
    [Fact]
    public void TestGetMovieByGenre()
    {
        const string MOVIE_GENRE = "Action";
        var movie = TestHelpers.CreateMovie(
            releaseDate: new DateOnly(1999, 5, 19),
            genre: MOVIE_GENRE
        );

        context.Movie.Add(movie);
        context.SaveChanges();
        var service = new MovieService(context);

        var movies = service?.GetMoviesByGenre(MOVIE_GENRE);

        Assert.Collection(movies, b => Assert.Equal(MOVIE_GENRE, b.genre));
    }

    #endregion

    #region GetAllMovies
    [Fact]
    public void TestGetAllMovies()
    {
        const string MOVIE_TITLE = "Star Wars: The Phantom Menace (Episode I)";
        var movie = TestHelpers.CreateMovie(
            id: 1,
            releaseDate: new DateOnly(1999, 5, 19),
            title: MOVIE_TITLE
        );

        const string MOVIE_TITLE_2 = "Star Wars 2: The Phantom Menace (Episode II)";
        var movie2 = TestHelpers.CreateMovie(
            id: 2,
            releaseDate: new DateOnly(2000, 5, 21),
            title: MOVIE_TITLE_2
        );

        context.Movie.AddRange(movie, movie2);
        context.SaveChanges();
        var service = new MovieService(context);
        var movies = service?.GetAll();

        Assert.Collection(
            movies,
            m => Assert.Equal(MOVIE_TITLE, m.title),
            m => Assert.Equal(MOVIE_TITLE_2, m.title)
        );
        Assert.Equal(2, movies.Count());
    }

    [Fact]
    public void TestGetAverageScoreOnAMovie()
    {
        const string MOVIE_TITLE = "Star Wars: The Phantom Menace (Episode I)";
        var movie = TestHelpers.CreateMovie(
            id: 1,
            releaseDate: new DateOnly(1999, 5, 19),
            title: MOVIE_TITLE
        );

        var movieReview1 = TestHelpers.CreateReview(
            id: 1,
            movieId: 1,
            score: 5,
            reviewDate: new DateTime(2024, 10, 10)
        );

        var movieReview2 = TestHelpers.CreateReview(
            id: 2,
            movieId: 1,
            score: 7,
            reviewDate: new DateTime(2024, 10, 10)
        );

        context.Movie.Add(movie);
        context.MovieReview.AddRange(movieReview1, movieReview2);
        context.SaveChanges();
        var service = new MovieService(context);
        var movies = service?.GetAll();

        Assert.Collection(movies, m => Assert.Equal(m.averageScore, 6.0));
    }
    #endregion

    #region GetMovieDetails
    [Fact]
    public void TestGetMovieDetails()
    {
        const string MOVIE_TITLE = "Star Wars: The Phantom Menace (Episode I)";
        var movie = TestHelpers.CreateMovie(
            id: 1,
            releaseDate: new DateOnly(1999, 5, 19),
            title: MOVIE_TITLE
        );

        context.Movie.Add(movie);
        context.SaveChanges();
        var service = new MovieService(context);

        var movieDetails = service.GetMovieDetails(1);

        Assert.Equal(MOVIE_TITLE, movieDetails.title);
    }
    #endregion

    #region GetCinemasWithMovie
    [Fact]
    public void TestGetCinemasWithMovie()
    {
        const string MOVIE_TITLE = "Star Wars: The Phantom Menace (Episode I)";
        var movie = TestHelpers.CreateMovie(
            id: 1,
            releaseDate: new DateOnly(1999, 5, 19),
            title: MOVIE_TITLE
        );

        var cinema = new Cinema
        {
            id = 4,
            name = "Princess Theatre",
            location = "Edmonton",
            MovieCinema = new List<MovieCinema>
            {
                new MovieCinema { movieId = 1, cinemaId = 1 }
            }
        };

        context.Movie.Add(movie);
        context.Cinema.Add(cinema);
        context.SaveChanges();
        var service = new MovieService(context);
        var cinemas = service.GetCinemasWithMovie(1);

        Assert.Collection(cinemas, c => Assert.Equal("Princess Theatre", c.name));
    }

    #endregion

    public void Dispose()
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
