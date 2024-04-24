namespace MovieHub.Models;


public class MovieReview
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public decimal Score { get; set; }
    public string Comment { get; set; }
    public DateOnly ReviewDate { get; set; }
}