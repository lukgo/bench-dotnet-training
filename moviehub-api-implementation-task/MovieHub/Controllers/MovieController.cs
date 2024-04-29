using Microsoft.AspNetCore.Mvc;
using MovieHub.Models;
using MovieHub.Services;

namespace MovieHub.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    readonly MovieService _service;

    public MovieController(MovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Movie> GetAll() => _service.GetAll();

    [HttpGet("~/get-movie-cinemas")]
    public IEnumerable<MovieCinema> GetMovieCinemas() => _service.GetMovieCinemas();

    [HttpGet("~/get-movie/title/{title}")]
    public IEnumerable<Movie> GetMovieByTitle(string title) => _service.GetMovieByTitle(title);

    [HttpGet("~/get-movie/genre/{genre}")]
    public IEnumerable<Movie> GetMovieByGenre(string genre) => _service.GetMovieByGenre(genre);

    [HttpGet("~/get-cinemas")]
    public IEnumerable<Cinema> GetCinemas() => _service.GetCinemas();
}
