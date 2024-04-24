namespace MovieHub.Models;


public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }

    public DateOnly ReleaseDate { get; set; }
    public DateOnly Genre { get; set; }
    public int Runtime { get; set; }
    public string Synopsis { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public string PrincessTheatreMovieId { get; set; }
    public ICollection<MovieReview>? MovieReviews { get; set; }
    public ICollection<MovieCinema>? MovieCinema { get; set; }
}