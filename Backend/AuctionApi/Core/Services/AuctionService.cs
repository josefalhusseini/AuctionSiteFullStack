using AuctionApi.Core.Interfaces;
using AuctionApi.Data.Entities;
using AuctionApi.Data.Interfaces;

namespace AuctionApi.Core.Services;

public class AuctionService : IAuctionService
{
    private readonly IAuctionRepo _repo;

    public AuctionService(IAuctionRepo repo)
    {
        _repo = repo;
    }

    public async Task<List<Auction>> GetActiveAsync()
    {
        return await _repo.GetActiveAsync();
    }

    public async Task<List<Auction>> SearchActiveAsync(string title)
    {
        return await _repo.SearchActiveAsync(title);
    }

    public async Task<Auction> CreateAsync(Auction auction)
    {
        auction.StartDate = DateTime.Now;
        return await _repo.CreateAsync(auction);
    }
}