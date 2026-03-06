using AuctionApi.Data.Entities;

namespace AuctionApi.Core.Interfaces;

public interface IBidService
{
    Task<List<Bid>> GetByAuctionIdAsync(int auctionId);
    Task<(bool Success, string? Error, Bid? CreatedBid)> CreateAsync(Bid bid);
}