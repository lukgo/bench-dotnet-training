using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Models;
using MovieHub.Services;

namespace MovieHub.Controllers;

[ApiController]
[Route("api")]
public class MovieController : ControllerBase
{
    readonly MovieService _service;

    public MovieController(MovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Movie> GetAll() => _service.GetAll();

    [HttpGet("~/get-movie/title/{title}")]
    public IEnumerable<Movie> GetMovieByTitle(string title) => _service.GetMoviesByTitle(title);

    [HttpGet("~/get-movie/genre/{genre}")]
    public IEnumerable<Movie> GetMovieByGenre(string genre) => _service.GetMoviesByGenre(genre);

    [HttpGet("~/get-cinemas/{movieId}")]
    public IEnumerable<Cinema> GetMovieDetailsWithCinemas(int movieId) =>
        _service.GetCinemasWithMovie(movieId);
}
