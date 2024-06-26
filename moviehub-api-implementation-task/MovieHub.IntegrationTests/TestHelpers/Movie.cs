using MovieHub.Models;

public class TestHelpers
{
    public static Movie CreateMovie(
        DateOnly releaseDate,
        int id = 123,
        string title = "Terminator 2",
        string genre = "Action",
        int runtime = 137,
        string synopsis = "A cyborg is sent from the future to protect",
        string director = "James Cameron",
        string rating = "R",
        string princessTheatreMovieId = "12345"
    )
    {
        return new Movie
        {
            id = id,
            title = title,
            releaseDate = releaseDate,
            genre = genre,
            runtime = runtime,
            synopsis = synopsis,
            director = director,
            rating = rating,
            princessTheatreMovieId = princessTheatreMovieId
        };
    }

    public static MovieReview CreateReview(
        DateTime reviewDate,
        int movieId,
        int id = 2,
        int score = 5,
        string comment = "Never seen a worse movie in my life"
    )
    {
        return new MovieReview
        {
            id = id,
            movieId = movieId,
            score = score,
            comment = comment,
            reviewDate = reviewDate,
        };
    }
}
