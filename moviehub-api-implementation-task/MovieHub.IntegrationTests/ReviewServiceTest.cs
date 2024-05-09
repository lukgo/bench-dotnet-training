using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieHub.Data;
using MovieHub.Services;

namespace MovieHub.IntegrationTests
{
    public class ReviewServiceTest
    {
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
    }
}
