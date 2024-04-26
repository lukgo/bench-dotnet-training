using MovieHub.Services;
using MovieHub.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<Movie> GetAll()
    {
        return _service.GetAll();
    }
}
