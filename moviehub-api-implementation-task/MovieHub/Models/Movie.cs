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

    public class MovieWithAverageScore()
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateOnly releaseDate { get; set; }
        public string genre { get; set; }
        public int runtime { get; set; }
        public string synopsis { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string princessTheatreMovieId { get; set; }
        public double averageScore { get; set; }

        public MovieWithAverageScore(Movie movie, double averageScore)
            : this()
        {
            id = movie.id;
            title = movie.title;
            releaseDate = movie.releaseDate;
            genre = movie.genre;
            runtime = movie.runtime;
            synopsis = movie.synopsis;
            director = movie.director;
            rating = movie.rating;
            princessTheatreMovieId = movie.princessTheatreMovieId;
            averageScore = averageScore;
        }
    }
}
