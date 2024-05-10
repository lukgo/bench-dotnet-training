using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieHub.Data;
using MovieHub.Services;

namespace MovieHub.IntegrationTests;

public class ReviewServiceTest
{
    private readonly MovieContext _context;

    public ReviewServiceTest()
    {
        var builder = new DbContextOptionsBuilder<MovieContext>();
        var _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        builder.UseSqlite(_connection);
        context = new MovieContext(builder.Options);
        context.Database.EnsureCreated();
    }

    public MovieContext context;

    [Fact]
    public void TestGetReviewsByMovie()
    {
        var movie = TestHelpers.CreateMovie(
            id: 1,
            releaseDate: new DateOnly(1999, 5, 19),
            title: "Star Wars: The Phantom Menace (Episode I)"
        );

        context.Movie.Add(movie);
        context.SaveChanges();

        var review = TestHelpers.CreateReview(
            reviewDate: new DateTime(2024, 10, 10),
            id: 1,
            movieId: movie.id
        );

        context.MovieReview.Add(review);
        context.SaveChanges();

        var service = new ReviewService(context);

        var reviews = service?.GetReviewsByMovie(movie.id);

        Assert.Collection(reviews, b => Assert.Equal(review.comment, b.comment));
    }

    [Fact]
    public void TestAddReview()
    {
        var movie = TestHelpers.CreateMovie(
            releaseDate: new DateOnly(1999, 5, 19),
            title: "Star Wars: The Phantom Menace (Episode I)"
        );

        context.Movie.Add(movie);
        context.SaveChanges();

        var review = TestHelpers.CreateReview(
            reviewDate: new DateTime(2024, 10, 10),
            id: 1,
            movieId: movie.id
        );

        var service = new ReviewService(context);

        service.AddReview(review);

        var reviews = context.MovieReview.Where(r => r.movieId == movie.id);

        Assert.Collection(reviews, b => Assert.Equal(review.comment, b.comment));
    }

    [Fact]
    public void TestUpdateReview()
    {
        var movie = TestHelpers.CreateMovie(releaseDate: new DateOnly(1999, 5, 19));

        context.Movie.Add(movie);
        context.SaveChanges();

        var review = TestHelpers.CreateReview(
            reviewDate: new DateTime(2024, 10, 10),
            id: 1,
            movieId: movie.id
        );

        context.MovieReview.Add(review);
        context.SaveChanges();

        var reviewService = new ReviewService(context);

        const string UPDATED_COMMENT = "Updated comment";

        review.comment = UPDATED_COMMENT;

        reviewService.UpdateReview(review);

        var updatedReview = context.MovieReview.Find(review.id);

        Assert.Equal(UPDATED_COMMENT, updatedReview.comment);
    }

    [Fact]
    public void TestDeleteReview()
    {
        var movie = TestHelpers.CreateMovie(releaseDate: new DateOnly(1999, 5, 19));

        context.Movie.Add(movie);
        context.SaveChanges();

        var review = TestHelpers.CreateReview(
            reviewDate: new DateTime(2023, 10, 10),
            id: 1,
            movieId: movie.id
        );

        context.MovieReview.Add(review);
        context.SaveChanges();

        var reviewService = new ReviewService(context);

        reviewService.DeleteReview(review.id);

        var deletedReview = context.MovieReview.Find(review.id);

        Assert.Null(deletedReview);
    }

    public void Dispose()
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
