using MovieHub.Data;
using MovieHub.Models;

namespace MovieHub.Services;

public class ReviewService
{
    private readonly MovieContext _context;

    public ReviewService(MovieContext context)
    {
        _context = context;
    }

    public IEnumerable<MovieReview> GetReviewsByMovie(int movieId) =>
        _context.MovieReview.Where(r => r.movieId == movieId);

    public void AddReview(MovieReview review)
    {
        _context.MovieReview.Add(review);
        _context.SaveChanges();
    }

    public void UpdateReview(MovieReview review)
    {
        _context.MovieReview.Update(review);
        _context.SaveChanges();
    }

    public void DeleteReview(int reviewId)
    {
        var review = _context.MovieReview.Find(reviewId);
        _context.MovieReview.Remove(review);
        _context.SaveChanges();
    }
}
