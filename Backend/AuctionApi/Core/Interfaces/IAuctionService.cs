using AuctionApi.Data.Entities;

namespace AuctionApi.Core.Interfaces;

public interface IAuctionService
{
    Task<List<Auction>> GetActiveAsync();
    Task<List<Auction>> SearchActiveAsync(string title);
    Task<Auction> CreateAsync(Auction auction);
}