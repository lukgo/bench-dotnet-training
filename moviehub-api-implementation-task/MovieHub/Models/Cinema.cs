using System.ComponentModel.DataAnnotations;

namespace MovieHub.Models;

public class Cinema
{
    public int id { get; set; }
    [MaxLength(64)]
    public string name { get; set; }
    public string location { get; set; }
    public ICollection<MovieCinema>? MovieCinema { get; set; }
}