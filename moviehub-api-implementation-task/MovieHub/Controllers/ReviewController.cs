using Microsoft.AspNetCore.Mvc;
using MovieHub.Models;
using MovieHub.Services;

namespace MovieHub.Controllers;

[ApiController]
[Route("api")]
public class ReviewController : ControllerBase
{
    readonly ReviewService _service;

    public ReviewController(ReviewService service)
    {
        _service = service;
    }

    [HttpGet("~/get-reviews/{movieId}")]
    public IEnumerable<MovieReview> GetReviewsByMovie(int movieId) =>
        _service.GetReviewsByMovie(movieId);

    [HttpPost("~/add-review")]
    public void AddReview(MovieReview review) => _service.AddReview(review);

    [HttpPut("~/update-review")]
    public void UpdateReview(MovieReview review) => _service.UpdateReview(review);

    [HttpDelete("~/delete-review/{reviewId}")]
    public void DeleteReview(int reviewId) => _service.DeleteReview(reviewId);
}
