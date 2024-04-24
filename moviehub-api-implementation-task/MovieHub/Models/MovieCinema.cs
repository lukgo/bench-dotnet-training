namespace MovieHub.Models;


public class MovieCinema
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public DateOnly Showtime { get; set; }
    public decimal TicketPrice { get; set; }
}