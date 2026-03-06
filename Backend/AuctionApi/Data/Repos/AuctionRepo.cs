using Microsoft.EntityFrameworkCore;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Data.Repos;

public class AuctionRepo : IAuctionRepo
{
    private readonly AuctionContext _context;

    public AuctionRepo(AuctionContext context)
    {
        _context = context;
    }

    public async Task<List<Auction>> GetActiveAsync()
    {
        return await _context.Auctions
            .Where(a => a.EndDate > DateTime.Now)
            .ToListAsync();
    }

    public async Task<List<Auction>> SearchActiveAsync(string title)
    {
        return await _context.Auctions
            .Where(a => a.EndDate > DateTime.Now && a.Title.Contains(title))
            .ToListAsync();
    }

    public async Task<Auction> CreateAsync(Auction auction)
    {
        _context.Auctions.Add(auction);
        await _context.SaveChangesAsync();
        return auction;
    }
}