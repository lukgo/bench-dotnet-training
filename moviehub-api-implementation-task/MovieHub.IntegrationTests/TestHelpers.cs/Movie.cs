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
}
