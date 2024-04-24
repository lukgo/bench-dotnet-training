namespace MovieHub.Models;


public class Cinema
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<MovieCinema>? MovieCinema { get; set; }

}