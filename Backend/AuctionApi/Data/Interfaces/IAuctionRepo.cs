using AuctionApi.Data.Entities;

namespace AuctionApi.Data.Interfaces;

public interface IAuctionRepo
{
    Task<List<Auction>> GetActiveAsync();
    Task<List<Auction>> SearchActiveAsync(string title);
    Task<Auction> CreateAsync(Auction auction);
}