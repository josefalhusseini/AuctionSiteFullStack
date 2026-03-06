using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Core.Services;

public class BidService : IBidService
{
    private readonly IBidRepo _repo;

    public BidService(IBidRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<Bid>> GetByAuctionIdAsync(int auctionId)
    {
        return await _repo.GetByAuctionIdAsync(auctionId);
    }

    public async Task<(bool Success, string? Error, Bid? CreatedBid)> CreateAsync(Bid bid)
    {
        var auction = await _repo.GetAuctionAsync(bid.AuctionId);
        if (auction == null)
            return (false, "Auktionen finns inte", null);

        var highest = await _repo.GetHighestBidAsync(bid.AuctionId);
        var minAmount = highest == null ? auction.Price : highest.Amount;

        if (bid.Amount <= minAmount)
            return (false, "Budet måste vara högre än nuvarande pris", null);

        bid.Date = DateTime.Now;

        var created = await _repo.CreateAsync(bid);
        return (true, null, created);
    }
}