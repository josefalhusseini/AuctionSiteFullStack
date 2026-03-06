using AuctionApi.Data.Entities;

namespace AuctionApi.Data.Interfaces;

public interface IBidRepo
{
    Task<List<Bid>> GetByAuctionIdAsync(int auctionId);
    Task<Auction?> GetAuctionAsync(int auctionId);
    Task<Bid?> GetHighestBidAsync(int auctionId);
    Task<Bid> CreateAsync(Bid bid);
}