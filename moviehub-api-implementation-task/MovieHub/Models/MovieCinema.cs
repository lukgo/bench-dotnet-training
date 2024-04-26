namespace MovieHub.Models;


public class MovieCinema
{
    public int id { get; set; }
    public int movieId { get; set; }
    public int cinemaId { get; set; }
    public DateOnly showtime { get; set; }
    public decimal ticketPrice { get; set; }
}