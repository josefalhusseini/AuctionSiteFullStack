namespace AuctionApi.Data.DTOs;

public class CreateAuctionDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public DateTime EndDate { get; set; }
    public int UserId { get; set; }
}