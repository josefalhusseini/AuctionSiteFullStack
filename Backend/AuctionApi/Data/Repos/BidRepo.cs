using Microsoft.EntityFrameworkCore;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Data.Repos;

public class BidRepo : IBidRepo
{
    private readonly AuctionContext _context;

    public BidRepo(AuctionContext context)
    {
        _context = context;
    }

    public async Task<List<Bid>> GetByAuctionIdAsync(int auctionId)
    {
        return await _context.Bids
            .Where(b => b.AuctionId == auctionId)
            .OrderByDescending(b => b.Amount)
            .ToListAsync();
    }

    public async Task<Auction?> GetAuctionAsync(int auctionId)
    {
        return await _context.Auctions
            .FirstOrDefaultAsync(a => a.Id == auctionId);
    }

    public async Task<Bid?> GetHighestBidAsync(int auctionId)
    {
        return await _context.Bids
            .Where(b => b.AuctionId == auctionId)
            .OrderByDescending(b => b.Amount)
            .FirstOrDefaultAsync();
    }

    public async Task<Bid> CreateAsync(Bid bid)
    {
        _context.Bids.Add(bid);
        await _context.SaveChangesAsync();
        return bid;
    }
}