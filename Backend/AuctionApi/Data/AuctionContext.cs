using Microsoft.EntityFrameworkCore;
using AuctionApi.Data.Entities;

namespace AuctionApi.Data;

public class AuctionContext : DbContext
{
    public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Auction> Auctions => Set<Auction>();
    public DbSet<Bid> Bids => Set<Bid>();
}