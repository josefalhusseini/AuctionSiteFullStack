namespace AuctionApi.Data.Entities;

public class Bid
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public int AuctionId { get; set; }
    public int UserId { get; set; }
}