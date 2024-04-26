namespace MovieHub.Models;

public class MovieReview
{
    public int id { get; set; }
    public int movieId { get; set; }
    public decimal score { get; set; }
    public string comment { get; set; }
    public DateTime reviewDate { get; set; }
}