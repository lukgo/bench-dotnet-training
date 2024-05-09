using System.ComponentModel.DataAnnotations;

namespace MovieHub.Models;

public class Movie
{
    public int id { get; set; }

    [MaxLength(128)]
    public string title { get; set; }
    public DateOnly releaseDate { get; set; }

    [MaxLength(64)]
    public string genre { get; set; }
    public int runtime { get; set; }
    public string synopsis { get; set; }

    [MaxLength(64)]
    public string director { get; set; }

    [MaxLength(8)]
    public string rating { get; set; }

    [MaxLength(16)]
    public string princessTheatreMovieId { get; set; }
    public ICollection<MovieReview>? MovieReviews { get; set; }
    public ICollection<MovieCinema>? MovieCinema { get; set; }
}
